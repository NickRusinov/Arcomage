using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Moq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Arcomage.Domain.Tests.Players
{
    public class ComputerPlayerTests
    {
        [Theory, AutoFixture]
        public void ArtificialIntelligenceCalledTest(Game game,
            [Frozen] Mock<IArtificialIntelligence> artificialIntelligenceMock,
            ComputerPlayer sut)
        {
            sut.Play(game);

            artificialIntelligenceMock.Verify(ai => ai.Execute(game), Times.Once);
        }
    }
}
