﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class RainbowCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            RainbowCard sut)
        {
            sut.Activate(game);

            Assert.Equal(21, game.Players.FirstPlayer.Buildings.Tower);
            Assert.Equal(21, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(8, game.Players.FirstPlayer.Resources.Gems);
        }
    }
}
