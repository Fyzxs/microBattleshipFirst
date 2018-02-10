namespace BattleShipMicro
{
    //TODO: Size belongs in this class. Need to clean up the points somehow
    public abstract class ShipDetector
    {
        private readonly int _directional;
        private readonly int _orthogonal;
        protected ShipDetector(int directional, int orthogonal)
        {
            _directional = directional;
            _orthogonal = orthogonal;
        }

        public abstract bool IsAt(int horzTargetCoord, int vertTargetCoord, int size);
        protected bool IsAtInternal(int priTargetCoord, int secTargetCoord, int size)
            => !(priTargetCoord < _directional || _directional + size <= priTargetCoord || secTargetCoord != _orthogonal);
    }

    public class HorizontalShipDetector : ShipDetector
    {
        public HorizontalShipDetector(int horzCoord, int vertCoord) : base(horzCoord, vertCoord) { }
        public override bool IsAt(int horzTargetCoord, int vertTargetCoord, int size) =>
            IsAtInternal(vertTargetCoord, horzTargetCoord, size);
    }

    public class VerticalShipDetector : ShipDetector
    {
        public VerticalShipDetector(int horzCoord, int vert) : base(vert, horzCoord) { }
        public override bool IsAt(int horzTargetCoord, int vertTargetCoord, int size) =>
            IsAtInternal(vertTargetCoord, horzTargetCoord, size);
    }
}