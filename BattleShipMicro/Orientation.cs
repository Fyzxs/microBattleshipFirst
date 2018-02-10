namespace BattleShipMicro {
    public class Orientation : IOrientation
    {
        public static readonly IOrientation Horizontal = new Orientation();
        public static readonly IOrientation Vertical = new Orientation();
        private Orientation() { }
        public bool IsHorizontal() => this == Horizontal;
    }
}