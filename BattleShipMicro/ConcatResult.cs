namespace BattleShipMicro {
    internal class ConcatResult : IResult
    {
        private readonly IResult _result;
        private readonly IResult _at;

        public ConcatResult(IResult result, IResult at)
        {
            _result = result;
            _at = at;
        }

        public override string ToString()
        {
            return _result.ToString() + _at.ToString();
        }
    }
}