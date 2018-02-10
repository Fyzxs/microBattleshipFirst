namespace BattleShipMicro
{
    public class Carrier : Ship
    {
        public Carrier(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 5;
        protected override IResult Result() => new Result("A");
        protected override IResult HitResult() => new Result("a");
    }
}