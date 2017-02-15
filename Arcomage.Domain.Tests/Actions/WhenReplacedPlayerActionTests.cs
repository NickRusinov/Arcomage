using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;
using static Arcomage.Domain.Players.PlayerSet;

namespace Arcomage.Domain.Tests.Actions
{
    public class WhenReplacedPlayerActionTests
    {
        [Theory, AutoFixture]
        public void PlayActionCalledWhenReplacedPlayerTest(
            [Frozen] Game game,
            [Frozen] Mock<IBeforePlayAction> playActionMock,
            WhenReplacedPlayerAction sut)
        {
            sut.Play(game);
            sut.Play(game);

            playActionMock.Verify(pa => pa.Play(game), Times.Once);
        }

        [Theory, AutoFixture]
        public void PlayActionCalledWhenNotReplacedPlayerTest(
            [Frozen] Game game,
            [Frozen] Mock<IBeforePlayAction> playActionMock,
            WhenReplacedPlayerAction sut)
        {
            sut.Play(game);
            game.Players.Kind = NextPlayerKind(game.Players.Kind);
            sut.Play(game);

            playActionMock.Verify(pa => pa.Play(game), Times.Exactly(2));
        }
    }
}
