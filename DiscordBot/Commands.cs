using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot;

public class Commands : BaseCommandModule
{
    [Command("hello")]
    public async Task HelloCommand(CommandContext context)
    {
        await context.Channel.SendMessageAsync($"Hello {context.User.Username}");
    }
    [Command("sum")]
    public async Task SumCommand(CommandContext context, int number1, int number2)
    {
        await context.Channel.SendMessageAsync($"{number1} + {number2} = {number1 + number2}");
    }
    [Command("repeat")]
    public async Task RepeatCommand(CommandContext context, params string[] str)
    {
        await context.Channel.SendMessageAsync(string.Join(' ', str));
    }
}
