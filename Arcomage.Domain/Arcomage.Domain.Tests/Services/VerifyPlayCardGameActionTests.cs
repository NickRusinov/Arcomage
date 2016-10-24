using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;
using Arcomage.Domain.Services;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class VerifyPlayCardGameActionTests
    {
        [Theory, AutoFixture]
        public void GameFinishedExceptionThrowsTest(
            [Frozen] Game game,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = true;

            Assert.Throws<GameFinishedException>(() => sut.Execute(game, 1));
        }

        [Theory, AutoFixture]
        public void NotCurrentPlayerExceptionThrowsTest(
            [Frozen] Game game,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;
            game.PlayerMode = PlayerMode.SecondPlayer;

            Assert.Throws<NotCurrentPlayerException>(() => sut.Execute(game, 1));
        }

        [Theory, AutoFixture]
        public void NotEnoughResourcesExceptionThrowsTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;
            game.PlayerMode = PlayerMode.FirstPlayer;
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(false);

            Assert.Throws<NotEnoughResourcesException>(() => sut.Execute(game, 1));
        }

        [Theory, AutoFixture]
        public void NoExceptionThrowsTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;
            game.PlayerMode = PlayerMode.FirstPlayer;
            game.FirstPlayer.CardSet.Cards[1] = cardMock.Object;
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.Execute(game, 1);
        }
    }
}
