namespace BattleShipMicro
{
    internal class ConcatDisplay : IDisplay
    {
        private readonly IDisplay _display;
        private readonly IDisplay _at;

        public ConcatDisplay(IDisplay display, IDisplay at)
        {
            _display = display;
            _at = at;
        }

        public override string ToString()
        {
            return _display.ToString() + _at.ToString();
        }
    }
}