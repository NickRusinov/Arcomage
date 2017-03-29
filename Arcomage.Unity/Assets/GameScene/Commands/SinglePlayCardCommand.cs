using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Commands
{
    public class SinglePlayCardCommand : Command<CardViewModel>
    {
        private readonly HumanPlayer player;

        public SinglePlayCardCommand(HumanPlayer player)
        {
            this.player = player;
        }

        public override Task Execute(CardViewModel viewModel)
        {
            player.SetPlayResult(new PlayResult(viewModel.Index, true));

            return base.Execute(viewModel);
        }
    }
}