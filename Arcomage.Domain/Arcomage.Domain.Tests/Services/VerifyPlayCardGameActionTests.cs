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

            Assert.Throws<GameFinishedException>(() => sut.Execute(1));
        }

        [Theory, AutoFixture]
        public void NotCurrentPlayerExceptionThrowsTest(
            [Frozen] Game game,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;

            Assert.Throws<NotCurrentPlayerException>(() => sut.Execute(1));
        }

        [Theory, AutoFixture]
        public void NotEnoughResourcesExceptionThrowsTest(
            [Frozen] Game game,
            [Frozen] Player player,
            [Frozen] Mock<Card> cardMock,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;
            game.FirstPlayer = player;
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(false);

            Assert.Throws<NotEnoughResourcesException>(() => sut.Execute(1));
        }

        [Theory, AutoFixture]
        public void NoExceptionThrowsTest(
            [Frozen] Game game,
            [Frozen] Player player,
            [Frozen] Mock<Card> cardMock,
            VerifyPlayCardGameAction sut)
        {
            game.IsFinished = false;
            game.FirstPlayer = player;
            game.FirstPlayer.CardSet.Cards[1] = cardMock.Object;
            cardMock.Setup(c => c.IsEnoughResources(It.IsAny<Resources>())).Returns(true);

            sut.Execute(1);
        }
    }
}
