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
    }

    public class Orientation : IOrientation
    {
        public static readonly IOrientation Horizontal = new Orientation();
        private Orientation() { }
    }

    public class AircraftCarrier : IShip
    {
        public AircraftCarrier(int horzCoord, int vertCoord, IOrientation orientation)
        {

        }

        public override string ToString()
        {
            return "AAAAA";
        }
    }

    public interface IOrientation { }

    public interface IShip { }
}
