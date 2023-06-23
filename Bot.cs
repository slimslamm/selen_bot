using System;
using System.Threading.Tasks;
using DSharpPlus;
using Newtonsoft.Json.Linq;
using selen_bot;
class Bot
{
    static async Task Main(string[] args)
    {
        ffCheck check = new();
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = Environment.GetEnvironmentVariable("selen_token"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
        });

        discord.MessageCreated += async (s, e) =>
        {
            if (e.Message.Content.ToLower().Equals("ff"))
                await e.Message.RespondAsync(check.upd());
        };

        await discord.ConnectAsync();
        await Task.Delay(-1);
    }
}