namespace BattleShipMicro
{
    public class FinalResult
    {
        private readonly IResult _aggregate;

        public FinalResult(IResult aggregate)
        {
            _aggregate = aggregate;
        }

        public override string ToString()
        {
            string result = _aggregate.ToString();
            return result == "" ? "." : result;
        }
    }
}