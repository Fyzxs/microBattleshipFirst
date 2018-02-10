namespace BattleShipMicro {
    public class Cruiser : Ship
    {
        public Cruiser(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 3;

        protected override IResult Result() => new Result("C");

        protected override IResult HitResult() => new Result("c");
    }
}