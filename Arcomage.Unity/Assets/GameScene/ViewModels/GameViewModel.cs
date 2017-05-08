using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Players;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class GameViewModel
    {
        public ResourcesViewModel LeftResources { get; set; }

        public BuildingsViewModel LeftBuildings { get; set; }

        public ResourcesViewModel RightResources { get; set; }

        public BuildingsViewModel RightBuildings { get; set; }

        public FinishedMenuViewModel FinishedMenu { get; set; }

        public HistoryViewModel History { get; set; }

        public HandViewModel Hand { get; set; }

        public TimerViewModel Timer { get; set; }

        public PlayerKind CurrentPlayerKind { get; set; }

        public PlayerKind UserPlayerKind { get; set; }

        public int DiscardOnly { get; set; }

        public int PlayAgain { get; set; }
    }
}
