using DiscordBot;

internal class Program
{
    public static void Main() => new Bot().RunAsync().GetAwaiter().GetResult();
}