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
            //Create an aircraft carrier at zero, zero horizontally
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);

            Approvals.Verify(subject);
        }
        [TestMethod]
        public void AircraftCarrierVerical()
        {
            //Create an aircraft carrier at zero, zero horizontally
            IShip subject = new AircraftCarrier(0, 0, Orientation.Vertical);

            Approvals.Verify(subject);
        }


        [TestMethod]
        public void AircraftCarrierReturnsSpecifiedIndicatorForBeingAtPoint()
        {
            //Create an aircraft carrier at zero, zero horizontally
            IShip subject = new AircraftCarrier(0, 0, Orientation.Horizontal);
            IResult result = subject.At(0, 0);
            Approvals.Verify(result);
        }

    }

    public interface IResult { }

    public class AircraftCarrier : IShip
    {
        private readonly IOrientation _orientation;

        public AircraftCarrier(int horzCoord, int vertCoord, IOrientation orientation)
        {
            _orientation = orientation;
        }

        public override string ToString()
        {
            return _orientation.IsHorizontal() ? "AAAAA" : "A\nA\nA\nA\nA";
        }

        public IResult At(int horzCoord, int vertCoord)
        {
            return new Result("A");
        }
    }

    public class Result : IResult
    {
        private readonly string _result;

        public Result(string result) => _result = result;
        public override string ToString() => _result;
    }

    public interface IShip
    {
        IResult At(int horzCoord, int vertCoord);
    }
}
