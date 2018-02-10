namespace BattleShipMicro {
    public class Cruiser : Ship
    {
        public Cruiser(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 3;

        protected override IDisplay Display() => new Display("C");

        protected override IDisplay HitDisplay() => new Display("c");
    }
}