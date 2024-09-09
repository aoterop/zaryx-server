using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface ItemBuffDao
    {
        Task<IItemBuff> ObtenerItemBuffPorId(int idItemBuff);
        Task<List<IItemBuff>> ObtenerItemsBuffPorItem(short itemGenerador);
        Task<List<IItemBuff>> ObtenerItemsBuffPorBuff(short buffGenerador);
        Task<List<IItemBuff>> ObtenerTodosLosItemBuff();
    }
}