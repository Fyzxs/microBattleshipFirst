namespace BattleShipMicro {
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(ShipDetector shipDetector) : base(shipDetector) { }

        protected override int Size() => 5;
        protected override IResult Result() => new Result("A");
        protected override IResult HitResult() => new Result("a");
    }
}