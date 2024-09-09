namespace Zaryx_DAO.Interfaces
{
    public interface IItemConsumo : IItem
    {
        short CuraHp { get; set; }
        short CuraMp { get; set; }
    }
}