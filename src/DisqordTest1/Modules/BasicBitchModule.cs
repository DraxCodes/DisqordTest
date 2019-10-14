using Disqord.Bot;
using Qmmands;
using System.Threading.Tasks;

namespace DisqordTest1.Modules
{
    public class BasicBitchModule : DiscordModuleBase
    {
        [Command("ping")]
        public async Task Ping()
            => await ReplyAsync("Pong!");
    }
}
