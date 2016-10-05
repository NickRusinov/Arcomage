using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
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
            
            Fixture.Register((IFixture f) => new FakeRandom() as Random);

            Fixture.Register((IFixture f) => f.CreateMany<Card>().ToList() as IReadOnlyCollection<Card>);

            Fixture.Register((IFixture f) => CreateBuildings(f));
            Fixture.Register((IFixture f) => CreateResources(f));
        }

        private static Buildings CreateBuildings(IFixture fixture)
        {
            return new Buildings { Wall = 5, Tower = 20 };
        }

        private static Resources CreateResources(IFixture fixture)
        {
            return new Resources { Quarry = 2, Bricks = 5, Magic = 2, Gems = 5, Dungeons = 2, Recruits = 5 };
        }
    }
}
