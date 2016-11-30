﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Entities;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class StripMineCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            StripMineCard sut)
        {
            sut.Activate(game);

            Assert.Equal(1, game.FirstPlayer.Resources.Quarry);
            Assert.Equal(15, game.FirstPlayer.Buildings.Wall);
            Assert.Equal(10, game.FirstPlayer.Resources.Gems);
        }
    }
}