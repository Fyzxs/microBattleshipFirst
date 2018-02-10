using ApprovalUtilities.Utilities;

namespace BattleShipMicro {
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
}