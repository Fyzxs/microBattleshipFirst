namespace BattleShipMicro {
    public class Result : IResult
    {
        private readonly string _result;

        public Result(string result) => _result = result;
        public override string ToString() => _result;
    }
}