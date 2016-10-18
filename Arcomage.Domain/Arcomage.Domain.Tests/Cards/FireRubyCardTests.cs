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
    public class FireRubyCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            FireRubyCard sut)
        {
            sut.Activate(game);

            Assert.Equal(26, game.FirstPlayer.Buildings.Tower);
            Assert.Equal(16, game.SecondPlayer.Buildings.Tower);
        }
    }
}
