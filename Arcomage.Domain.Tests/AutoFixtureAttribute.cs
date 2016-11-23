using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Arcomage.Domain.Tests.Internal;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit2;

namespace Arcomage.Domain.Tests
{
    public sealed class AutoFixtureAttribute : AutoDataAttribute
    {
        public AutoFixtureAttribute()
        {
            Fixture.Customize(new AutoConfiguredMoqCustomization());
            Fixture.Customize<Game>(cc => cc.With(g => g.PlayAgain, 0));
            
            Fixture.Register((IFixture f) => new FakeRandom() as Random);

            Fixture.Register((IFixture f) => f.CreateMany<Card>().ToList() as IReadOnlyCollection<Card>);

            Fixture.Register((IFixture f) => PlayerMode.FirstPlayer);
            Fixture.Register((IFixture f) => CreatePlayer(f));
            Fixture.Register((IFixture f) => CreateBuildings(f));
            Fixture.Register((IFixture f) => CreateResources(f));
        }

        private static Player CreatePlayer(IFixture fixture)
        {
            return fixture.Create<HumanPlayer>();
        }

        private static Buildings CreateBuildings(IFixture fixture)
        {
            return new Buildings(5, 20);
        }

        private static Resources CreateResources(IFixture fixture)
        {
            return new Resources(2, 5, 2, 5, 2, 5);
        }
    }
}
