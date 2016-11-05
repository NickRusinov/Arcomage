using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Actions
{
    public class WhenReplacedPlayerActionTests
    {
        [Theory, AutoFixture]
        public void PlayActionCalledWhenReplacedPlayerTest(
            [Frozen] Game game,
            [Frozen] Mock<IPlayAction> playActionMock,
            WhenReplacedPlayerAction sut)
        {
            sut.Execute(game, game.FirstPlayer);
            sut.Execute(game, game.SecondPlayer);

            playActionMock.Verify(pa => pa.Execute(game, game.FirstPlayer), Times.Once);
            playActionMock.Verify(pa => pa.Execute(game, game.SecondPlayer), Times.Once);
        }

        [Theory, AutoFixture]
        public void PlayActionCalledWhenNotReplacedPlayerTest(
            [Frozen] Game game,
            [Frozen] Mock<IPlayAction> playActionMock,
            WhenReplacedPlayerAction sut)
        {
            sut.Execute(game, game.FirstPlayer);
            sut.Execute(game, game.FirstPlayer);

            playActionMock.Verify(pa => pa.Execute(game, game.FirstPlayer), Times.Once);
            playActionMock.Verify(pa => pa.Execute(game, game.SecondPlayer), Times.Never);
        }
    }
}
