using System.Collections.Generic;
using System.Linq;

namespace BattleShipMicro {
    public class ShipCollection : IShipCollection
    {
        private readonly List<IShip> _ships = new List<IShip>();
        public void ShotAt(int horzCoord, int vertCoord)
        {
            foreach (IShip ship in _ships)
            {
                ship.HitAt(horzCoord, vertCoord);
            }
        }

        public void Add(IShip ship) => _ships.Add(ship);

        public IDisplay Result(int horzCoord, int vertCoord) =>
            _ships.Aggregate(new Display("") as IDisplay, (current, ship) => new ConcatDisplay(current, ship.At(horzCoord, vertCoord)));
    }
}