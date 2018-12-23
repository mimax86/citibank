using Citi.Service.Data.Positions;
using FluentAssertions;
using NUnit.Framework;

namespace Citi.Tests
{
    [TestFixture]
    public class PositionItemTest
    {
        [Test]
        public void PositionItem_Is_Updated_By_Spot_Change()
        {
            var position = new PositionItem
            {
                Quantity = 2
            };
            position.UpdateSpot(10.234m);
            position.Quantity.Should().Be(2);
            position.Spot.Should().Be(10.234m);
            position.Position.Should().Be(2 * 10.234m);
            position.Delta.Should().Be(2 * 10.234m * 0.01m);
        }
    }
}