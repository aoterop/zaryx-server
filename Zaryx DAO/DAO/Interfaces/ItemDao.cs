using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface ItemDao<T> where T : IItem
    {
        Task<T> ObtenerItemPorId(short idItem);
        Task<List<T>> ObtenerTodosLosItems();
    }
}