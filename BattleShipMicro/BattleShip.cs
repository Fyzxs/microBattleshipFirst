namespace BattleShipMicro {
    public class BattleShip : Ship
    {
        public BattleShip(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 2;

        protected override IResult Result() => new Result("B");

        protected override IResult HitResult() => new Result("b");
    }
}