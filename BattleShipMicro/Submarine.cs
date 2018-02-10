namespace BattleShipMicro {
    public class Submarine : Ship
    {
        public Submarine(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 3;

        protected override IResult Result() => new Result("S");

        protected override IResult HitResult() => new Result("s");
    }
}