using System;
using Disqord;
using Disqord.Bot;
using Disqord.Logging;
using System.Threading;
using System.Reflection;
using DisqordTest1.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DisqordTest1
{
    public class BotClient
    {
        private readonly string _Token = "SUPER_SECRET";
        public async Task Initialise(CancellationToken cancellationToken)
        {
            var disqordConfig = new DiscordBotConfiguration
            {
                Prefixes = new[] { ".." },
                HasMentionPrefix = true,
                ProviderFactory = bot => SetupProvider()
            };
            using (var bot = new DiscordBot(TokenType.Bot, _Token, disqordConfig))
            {
                bot.Logger.MessageLogged += Log;
                bot.AddModules(Assembly.GetEntryAssembly());
                await bot.RunAsync(cancellationToken);
            }
        }

        private void Log(object sender, MessageLoggedEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        private IServiceProvider SetupProvider()
            => new ServiceCollection()
            .AddSingleton<ILogService, LogService>()
            .BuildServiceProvider();
    }
}
