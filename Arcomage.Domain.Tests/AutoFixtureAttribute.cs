using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Players;
using Arcomage.Domain.Resources;
using Arcomage.Domain.Rules;
using Arcomage.Domain.Tests.Internal;
using Moq;
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
            Fixture.Customize<Game>(cc => cc.With(g => g.DiscardOnly, 0));

            Fixture.Freeze<Mock<Card>>().SetupGet(c => c.Price).Returns(10);
            Fixture.Freeze<Mock<Card>>().SetupGet(c => c.Kind).Returns(ResourceKind.Bricks);
            
            Fixture.Register((IFixture f) => PlayerKind.First);
            Fixture.Register((IFixture f) => ResourceKind.Bricks);

            Fixture.Register((IFixture f) => f.Create<HumanPlayer>() as Player);
            Fixture.Register((IFixture f) => f.CreateMany<Card>().ToList() as IReadOnlyCollection<Card>);

            Fixture.Register((IFixture f) => new BuildingSet(5, 20));
            Fixture.Register((IFixture f) => new ResourceSet(2, 5, 2, 5, 2, 5));
            Fixture.Register((IFixture f) => new ClassicRuleInfo(f.Create<string>(), 2, 5, 2, 5, 2, 5, 5, 20, 50, 150));
            Fixture.Register((IFixture f) => new ClassicDeckInfo(f.Create<string>(), new FakeRandom()));
            Fixture.Register((IFixture f) => new InfinityDeckInfo(f.Create<string>(), new FakeRandom()));
        }
    }
}
