namespace BattleShipMicro
{
    public class Carrier : Ship
    {
        public Carrier(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 5;
        protected override IDisplay Display() => new Display("A");
        protected override IDisplay HitDisplay() => new Display("a");
    }
}