using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipMicro
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingAtPointHorizontally()
        {
            IShip subject = new Carrier(new HorizontalShipDetector(0, 0));
            IDisplay display = subject.At(0, 0);
            display.ToString().Should().Be("A");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPointHorizontally()
        {
            IShip subject = new Carrier(new HorizontalShipDetector(0, 0));
            IDisplay display = subject.At(1, 1);
            display.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForLessThanPointHorizontally()
        {
            IShip subject = new Carrier(new HorizontalShipDetector(1, 0));
            IDisplay display = subject.At(0, 0);
            display.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHigherThanPointHorizontally()
        {
            IShip subject = new Carrier(new HorizontalShipDetector(1, 1));
            IDisplay display = subject.At(10, 1);
            display.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPointVertically()
        {
            IShip subject = new Carrier(new VerticalShipDetector(0, 0));
            IDisplay display = subject.At(1, 1);
            display.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForLessThanPointVertically()
        {
            IShip subject = new Carrier(new VerticalShipDetector(1, 1));
            IDisplay display = subject.At(1, 0);
            display.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHigherThanPointVertically()
        {
            IShip subject = new Carrier(new VerticalShipDetector(0, 0));
            IDisplay display = subject.At(0, 10);
            display.ToString().Should().Be("");
        }

        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingHitAtPointHorizontally()
        {
            IShip subject = new Carrier(new HorizontalShipDetector(0, 0));
            subject.HitAt(0, 0);
            IDisplay display = subject.At(0, 0);
            display.ToString().Should().Be("a");
        }

    }
}
