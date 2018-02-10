using System.Collections.Generic;
using System.Linq;

namespace BattleShipMicro
{
    public abstract class Ship : IShip
    {
        private readonly List<KeyValuePair<int, int>> _hits = new List<KeyValuePair<int, int>>();//So wants to be a thing
        private readonly ShipDetector _shipDetector;

        protected Ship(ShipDetector shipDetector) => _shipDetector = shipDetector;

        protected abstract int Size();

        protected abstract IDisplay Display();
        protected abstract IDisplay HitDisplay();

        public IDisplay At(int horzCoord, int vertCoord) =>
            _shipDetector.IsAt(horzCoord, vertCoord, Size()) ? InternalResult(horzCoord, vertCoord) : new Display("");

        public bool HitAt(int horzCoord, int vertCoord)
        {
            if (!_shipDetector.IsAt(horzCoord, vertCoord, Size()))
                return false;

            _hits.Add(new KeyValuePair<int, int>(horzCoord, vertCoord));
            return true;
        }

        private IDisplay InternalResult(int horzCoord, int vertCoord) => IsHitAt(horzCoord, vertCoord) ? HitDisplay() : Display();
        private bool IsHitAt(int horzCoord, int vertCoord) => _hits.Any(hit => hit.Key == horzCoord && hit.Value == vertCoord);
    }
}