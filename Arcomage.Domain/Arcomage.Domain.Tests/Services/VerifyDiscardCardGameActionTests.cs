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

            Assert.Throws<GameFinishedException>(() => sut.Execute(game, 1));
        }

        [Theory, AutoFixture]
        public void NotCurrentPlayerExceptionThrowsTest(
            [Frozen] Game game,
            VerifyDiscardCardGameAction sut)
        {
            game.IsFinished = false;
            game.PlayerMode = PlayerMode.SecondPlayer;

            Assert.Throws<NotCurrentPlayerException>(() => sut.Execute(game, 1));
        }

        [Theory, AutoFixture]
        public void NoExceptionThrowsTest(
            [Frozen] Game game,
            VerifyDiscardCardGameAction sut)
        {
            game.IsFinished = false;
            game.PlayerMode = PlayerMode.FirstPlayer;

            sut.Execute(game, 1);
        }
    }
}
