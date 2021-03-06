﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class ShadowFaerieCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            ShadowFaerieCard sut)
        {
            sut.Activate(game);

            Assert.Equal(18, game.Players.SecondPlayer.Buildings.Tower);
            Assert.Equal(1, game.PlayAgain);
        }
    }
}
