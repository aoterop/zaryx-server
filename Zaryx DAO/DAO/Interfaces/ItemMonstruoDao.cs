using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface ItemMonstruoDao
    {
        Task<IItemMonstruo> ObtenerItemMonstruoPorId(short idItemMonstruo);
        Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeTodosLosMonstruos();
        Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeUnMonstruo(short monstruoArrojador);
    }
}