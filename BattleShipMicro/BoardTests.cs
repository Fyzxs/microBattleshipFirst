using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipMicro
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void BoardHasShips()
        {
            //Add all 5 ships to the board
            IBoard board = new Board();

            board.Add(new Carrier(new HorizontalShipDetector(0, 0)));
            board.Add(new BattleShip(new HorizontalShipDetector(0, 1)));
            board.Add(new Cruiser(new HorizontalShipDetector(0, 2)));
            board.Add(new Submarine(new HorizontalShipDetector(0, 3)));
            board.Add(new Destroyer(new VerticalShipDetector(0, 4)));

            Approvals.Verify(board);
        }

        [TestMethod]
        [UseReporter(typeof(DiffReporter))]
        public void BoardHasHitShips()
        {
            //Add all 5 ships to the board
            IBoard board = new Board();

            board.Add(new Carrier(new HorizontalShipDetector(0, 0)));
            board.Add(new BattleShip(new HorizontalShipDetector(0, 1)));
            board.Add(new Cruiser(new HorizontalShipDetector(0, 2)));
            board.Add(new Submarine(new HorizontalShipDetector(0, 3)));
            board.Add(new Destroyer(new VerticalShipDetector(0, 4)));
            board.ShotAt(0, 0);
            board.ShotAt(0, 1);
            board.ShotAt(0, 2);
            board.ShotAt(0, 3);
            board.ShotAt(0, 4);
            Approvals.Verify(board);
        }
    }
}
