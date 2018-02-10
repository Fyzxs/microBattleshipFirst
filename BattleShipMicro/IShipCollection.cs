namespace BattleShipMicro {
    public interface IShipCollection {
        void ShotAt(int horzCoord, int vertCoord);
        void Add(IShip ship);
        IDisplay Result(int horzCoord, int vertCoord);
    }
}