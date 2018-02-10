namespace BattleShipMicro
{
    public class Submarine : Ship
    {
        public Submarine(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 3;

        protected override IDisplay Display() => new Display("S");

        protected override IDisplay HitDisplay() => new Display("s");
    }
}