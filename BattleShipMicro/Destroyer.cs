namespace BattleShipMicro {
    public class Destroyer : Ship
    {
        public Destroyer(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 4;

        protected override IDisplay Display() => new Display("D");

        protected override IDisplay HitDisplay() => new Display("d");
    }
}