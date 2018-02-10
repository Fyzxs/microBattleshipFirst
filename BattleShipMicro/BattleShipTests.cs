using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipMicro
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class BattleShipTests
    {
        [TestMethod]
        public void AircraftCarrierHorizontal()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);

            Approvals.Verify(subject);
        }
        [TestMethod]
        public void AircraftCarrierVerical()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Vertical);

            Approvals.Verify(subject);
        }


        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingAtPoint()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);
            IResult result = subject.At(0, 0);
            Approvals.Verify(result);
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForNotBeingAtPoint()
        {
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);
            IResult result = subject.At(1, 1);
            Approvals.Verify(result);
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHorizontalLessThanPoint()
        {
            IShip subject = new AircraftCarrier(1, 0, Orientation.Horizontal);
            IResult result = subject.At(0, 1);
            Approvals.Verify(result);
        }
        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForHorizontalHigherThanPoint()
        {
            IShip subject = new AircraftCarrier(1, 0, Orientation.Horizontal);
            IResult result = subject.At(10, 1);
            Approvals.Verify(result);
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

        public override string ToString()
        {
            return _orientation.IsHorizontal() ? "AAAAA" : "A\nA\nA\nA\nA";
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
