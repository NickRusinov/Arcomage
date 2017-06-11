using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Arcomage.Network.Quartz
{
    public class QuartzKeyGenerator
    {
        public static JobKey JobForCreateGame() =>
            new JobKey("CreateGameJob");

        public static TriggerKey TriggerForCreateGame() => 
            new TriggerKey("CreateGameTrigger");

        public static JobKey JobForPlayGame(GameContext gameContext) =>
            new JobKey("PlayGameJob:" + gameContext.Id);

        public static TriggerKey TriggerForPlayGame(GameContext gameContext) => 
            new TriggerKey("PlayGameTrigger:" + gameContext.Id);
    }
}
