using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemRepository<T> where T : IItem
    {
        Task<T> ObtenerItemPorId(short idItem);
        Task<List<T>> ObtenerTodosLosItems();
    }
}