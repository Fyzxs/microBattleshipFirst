namespace BattleShipMicro
{
    public abstract class ShipDetector
    {
        private readonly int _primaryCoord;
        private readonly int _secondaryCoord;
        protected ShipDetector(int primaryCoord, int secondaryCoord)
        {
            _primaryCoord = primaryCoord;
            _secondaryCoord = secondaryCoord;
        }

        public abstract bool IsAt(int horzTargetCoord, int vertTargetCoord, int size);
        protected bool IsAtInternal(int priTargetCoord, int secTargetCoord, int size)
            => !(priTargetCoord < _primaryCoord || _primaryCoord + size <= priTargetCoord || secTargetCoord != _secondaryCoord);
    }

    public class HorizontalShipDetector : ShipDetector
    {
        public HorizontalShipDetector(int horzCoord, int vertCoord) : base(horzCoord, vertCoord) { }
        public override bool IsAt(int horzTargetCoord, int vertTargetCoord, int size) =>
            IsAtInternal(vertTargetCoord, horzTargetCoord, size);
    }

    public class VerticalShipDetector : ShipDetector
    {
        public VerticalShipDetector(int horzCoord, int vertCoord) : base(vertCoord, horzCoord) { }
        public override bool IsAt(int horzTargetCoord, int vertTargetCoord, int size) =>
            IsAtInternal(vertTargetCoord, horzTargetCoord, size);
    }
}