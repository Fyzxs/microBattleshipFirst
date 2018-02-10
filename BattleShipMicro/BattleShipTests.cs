using ApprovalTests.Reporters;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipMicro
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class BattleShipTests
    {
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingAtPointHorizontally()
        {
            IShip subject = new AircraftCarrier(new HorizontalShipDetector(0, 0));
            IResult result = subject.At(0, 0);
            result.ToString().Should().Be("A");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPointHorizontally()
        {
            IShip subject = new AircraftCarrier(new HorizontalShipDetector(0, 0));
            IResult result = subject.At(1, 1);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForLessThanPointHorizontally()
        {
            IShip subject = new AircraftCarrier(new HorizontalShipDetector(1, 0));
            IResult result = subject.At(0, 0);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHigherThanPointHorizontally()
        {
            IShip subject = new AircraftCarrier(new HorizontalShipDetector(1, 1));
            IResult result = subject.At(10, 1);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPointVertically()
        {
            IShip subject = new AircraftCarrier(new VerticalShipDetector(0, 0));
            IResult result = subject.At(1, 1);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForLessThanPointVertically()
        {
            IShip subject = new AircraftCarrier(new VerticalShipDetector(1, 1));
            IResult result = subject.At(1, 0);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHigherThanPointVertically()
        {
            IShip subject = new AircraftCarrier(new VerticalShipDetector(0, 0));
            IResult result = subject.At(0, 10);
            result.ToString().Should().Be("");
        }

    }

    public abstract class Ship : IShip
    {
        private readonly ShipDetector _shipDetector;

        protected Ship(ShipDetector shipDetector) => _shipDetector = shipDetector;

        protected abstract int Size();

        public IResult At(int horzCoord, int vertCoord) =>
            _shipDetector.IsAt(horzCoord, vertCoord, Size()) ? new Result("A") : new Result("");
    }

    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 5;
    }
}
