namespace BattleShipMicro {
    public class BattleShip : Ship
    {
        public BattleShip(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 2;

        protected override IDisplay Display() => new Display("B");

        protected override IDisplay HitDisplay() => new Display("b");
    }
}