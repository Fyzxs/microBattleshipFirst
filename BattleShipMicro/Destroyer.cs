namespace BattleShipMicro {
    public class Destroyer : Ship
    {
        public Destroyer(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 4;

        protected override IResult Result() => new Result("D");

        protected override IResult HitResult() => new Result("d");
    }
}