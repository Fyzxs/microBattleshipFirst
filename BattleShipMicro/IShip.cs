namespace BattleShipMicro
{
    public interface IShip
    {
        IDisplay At(int horzCoord, int vertCoord);
        bool HitAt(int horzCoord, int vertCoord);
    }
}