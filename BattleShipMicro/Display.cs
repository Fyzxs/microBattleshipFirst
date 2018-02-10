namespace BattleShipMicro
{
    public class Display : IDisplay
    {
        private readonly string _display;

        public Display(string display) => _display = display;
        public override string ToString() => _display;
    }
}