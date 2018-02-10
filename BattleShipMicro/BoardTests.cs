using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

    //TODO: Ship Collision
    public class Board : IBoard
    {
        private readonly ShipCollection _ships = new ShipCollection();
        public void Add(IShip ship) => _ships.Add(ship);
        public void ShotAt(int horzCoord, int vertCoord) => _ships.ShotAt(horzCoord, vertCoord);

        public override string ToString()
        {
            return StringUtils.DisplayGrid(11, 10, PrintPoint);
        }

        private string PrintPoint(int horzCoord, int vertCoord)
        {
            return new FinalResult(_ships.Result(horzCoord, vertCoord)).ToString();
        }
    }

    public class ShipCollection : IShipCollection
    {
        private readonly List<IShip> _ships = new List<IShip>();//Ship Collection
        public void ShotAt(int horzCoord, int vertCoord)
        {
            foreach (IShip ship in _ships)
            {
                ship.HitAt(horzCoord, vertCoord);
            }
        }

        public void Add(IShip ship) => _ships.Add(ship);

        public IResult Result(int horzCoord, int vertCoord) =>
            _ships.Aggregate(new Result("") as IResult, (current, ship) => new ConcatResult(current, ship.At(horzCoord, vertCoord)));
    }

    public interface IShipCollection { }

    public interface IBoard
    {
        void Add(IShip ship);
        void ShotAt(int horzCoord, int vertCoord);
    }
}
