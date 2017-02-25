using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Services;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Services
{
    public class PlayCardCriteriaTests
    {
        [Theory, AutoFixture]
        public void CanPlayCardTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            PlayCardCriteria sut)
        {
            game.Players.FirstPlayer.Resources[cardMock.Object.Kind].Value = cardMock.Object.Price + 1;

            var canPlayCard = sut.CanPlayCard(game, game.Players.FirstPlayer, 1);

            Assert.True(canPlayCard);
        }

        [Theory, AutoFixture]
        public void CanPlayCardWhenNotEnoughResourcesTest(
            [Frozen] Mock<Card> cardMock,
            [Frozen] Game game,
            PlayCardCriteria sut)
        {
            game.Players.FirstPlayer.Resources[cardMock.Object.Kind].Value = cardMock.Object.Price - 1;

            var canPlayCard = sut.CanPlayCard(game, game.Players.FirstPlayer, 1);

            Assert.False(canPlayCard);
        }
    }
}
