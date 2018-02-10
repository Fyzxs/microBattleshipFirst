using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipMicro
{
    [TestClass]
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

        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingHitAtPointHorizontally()
        {
            IShip subject = new AircraftCarrier(new HorizontalShipDetector(0, 0));
            subject.HitAt(0, 0);
            IResult result = subject.At(0, 0);
            result.ToString().Should().Be("a");
        }

    }

    public abstract class Ship : IShip
    {
        private readonly List<KeyValuePair<int, int>> _hits = new List<KeyValuePair<int, int>>();//So wants to be a thing
        private readonly ShipDetector _shipDetector;

        protected Ship(ShipDetector shipDetector) => _shipDetector = shipDetector;

        protected abstract int Size();

        public IResult At(int horzCoord, int vertCoord) =>
            _shipDetector.IsAt(horzCoord, vertCoord, Size()) ? InternalResult(horzCoord, vertCoord) : new Result("");

        private IResult InternalResult(int horzCoord, int vertCoord) => IsHitAt(horzCoord, vertCoord) ? HitResult() : Result();

        public bool HitAt(int horzCoord, int vertCoord)
        {
            if (!_shipDetector.IsAt(horzCoord, vertCoord, Size()))
                return false;

            _hits.Add(new KeyValuePair<int, int>(horzCoord, vertCoord));
            return true;
        }

        protected bool IsHitAt(int horzCoord, int vertCoord) => _hits.Any(hit => hit.Key == horzCoord && hit.Value == vertCoord);

        protected abstract IResult Result();
        protected abstract IResult HitResult();
    }

    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 5;
        protected override IResult Result() => new Result("A");
        protected override IResult HitResult() => new Result("a");
    }
}
