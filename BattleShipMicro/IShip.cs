namespace BattleShipMicro
{
    public interface IShip
    {
        IResult At(int horzCoord, int vertCoord);
        bool HitAt(int horzCoord, int vertCoord);
    }
}