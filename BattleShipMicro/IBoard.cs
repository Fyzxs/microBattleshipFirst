namespace BattleShipMicro
{
    public interface IBoard
    {
        void Add(IShip ship);
        void ShotAt(int horzCoord, int vertCoord);
    }
}