using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;
using Arcomage.Domain.Services;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class VerifyDiscardCardGameActionTests
    {
        [Theory, AutoFixture]
        public void GameFinishedExceptionThrowsTest(
            [Frozen] Game game,
            VerifyDiscardCardGameAction sut)
        {
            game.IsFinished = true;

            Assert.Throws<GameFinishedException>(() => sut.Execute(1));
        }

        [Theory, AutoFixture]
        public void NotCurrentPlayerExceptionThrowsTest(
            [Frozen] Game game,
            VerifyDiscardCardGameAction sut)
        {
            game.IsFinished = false;

            Assert.Throws<NotCurrentPlayerException>(() => sut.Execute(1));
        }

        [Theory, AutoFixture]
        public void NoExceptionThrowsTest(
            [Frozen] Game game,
            [Frozen] Player player,
            VerifyDiscardCardGameAction sut)
        {
            game.IsFinished = false;
            game.FirstPlayer = player;

            sut.Execute(1);
        }
    }
}
