namespace BattleShipMicro
{
    public class FinalResult
    {
        private readonly IDisplay _aggregate;

        public FinalResult(IDisplay aggregate)
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