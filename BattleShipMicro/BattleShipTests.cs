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
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingAtPoint()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);
            IResult result = subject.At(0, 0);
            result.ToString().Should().Be("A");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPoint()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);
            IResult result = subject.At(1, 1);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHorizontalLessThanPoint()
        {
            IShip subject = new AircraftCarrier(1, 0, Orientation.Horizontal);
            IResult result = subject.At(0, 1);
            result.ToString().Should().Be("");
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHorizontalHigherThanPoint()
        {
            IShip subject = new AircraftCarrier(1, 0, Orientation.Horizontal);
            IResult result = subject.At(10, 1);
            result.ToString().Should().Be("");
        }

    }

    public class AircraftCarrier : IShip
    {
        private const int _size = 5;
        private readonly int _horzCoord;
        private readonly int _vertCoord;
        private readonly IOrientation _orientation;

        public AircraftCarrier(int horzCoord, int vertCoord, IOrientation orientation)
        {
            _horzCoord = horzCoord;
            _vertCoord = vertCoord;
            _orientation = orientation;
        }


        public IResult At(int horzCoord, int vertCoord)
        {
            if (_orientation.IsHorizontal())
            {
                if (horzCoord < _horzCoord)
                    return new Result("");
                if (_horzCoord + _size <= horzCoord)
                    return new Result("");
                if (vertCoord != _vertCoord)
                    return new Result("");
            }
            return new Result("A");
        }
    }
}
