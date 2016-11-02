using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Entities;
using Xunit;

namespace Arcomage.Domain.Tests.Cards
{
    public class MadCowDiseaseCardTests
    {
        [Theory, AutoFixture]
        public void ActivateTest(Game game,
            MadCowDiseaseCard sut)
        {
            sut.Activate(game);

            Assert.Equal(0, game.FirstPlayer.Resources.Recruits);
            Assert.Equal(0, game.SecondPlayer.Resources.Recruits);
        }
    }
}

