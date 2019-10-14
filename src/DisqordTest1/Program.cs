using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisqordTest1
{
    class Program
    {
        private static Task Main(string[] args)
        {
            var ct = new CancellationTokenSource();
            var bot = new BotClient();

            _ = bot.Initialise(ct.Token);

            while (!ct.IsCancellationRequested)
            {
                var input = Console.ReadLine();
                if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    ct.Cancel();
                }
            }

            return Task.CompletedTask;
        }
    }
}
