using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Newtonsoft.Json;
using System.Text;

namespace DiscordBot;


public class Bot
{
    public DiscordClient Client { get; private set; }
    public InteractivityExtension Interactivity { get; private set; }
    public CommandsNextExtension Commands { get; private set; }


    public async Task RunAsync()
    {
        ConfigJSON configJson = JsonConvert.DeserializeObject<ConfigJSON>(await ReadJson());

        Client = new DiscordClient(new DiscordConfiguration()
        {
            Token = configJson.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true,
        });

        Client.UseInteractivity(new InteractivityConfiguration()
        {
            Timeout = TimeSpan.FromMinutes(2)
        });

        CommandsNextConfiguration commandsConfig = new()
        {
            StringPrefixes = new List<string>() { configJson.Prefix },
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = false,
        };

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }


    private static async Task<string> ReadJson()
    {
        string json;
        using (FileStream fs = File.OpenRead("config.json"))
        {
            using StreamReader sr = new(fs, new UTF8Encoding(false));
            json = await sr.ReadToEndAsync();
        }

        return json;
    }

    private Task OnClientReady(ReadyEventArgs e)
    {
        return Task.CompletedTask;
    }
}
