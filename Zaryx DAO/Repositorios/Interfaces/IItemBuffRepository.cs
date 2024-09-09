using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemBuffRepository
    {
        Task<IItemBuff> ObtenerItemBuffPorId(int idItemBuff);
        Task<List<IItemBuff>> ObtenerItemsBuffPorItem(short itemGenerador);
        Task<List<IItemBuff>> ObtenerItemsBuffPorBuff(short buffGenerador);
        Task<List<IItemBuff>> ObtenerTodosLosItemBuff();
        IItemBuff CrearItemBuff();
    }
}