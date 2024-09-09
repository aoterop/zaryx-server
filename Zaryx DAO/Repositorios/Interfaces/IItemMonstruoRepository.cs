using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemMonstruoRepository
    {
        Task<IItemMonstruo> ObtenerItemMonstruoPorId(short idItemMonstruo);
        Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeTodosLosMonstruos();
        Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeUnMonstruo(short monstruoArrojador);
        IItemMonstruo CrearItemMonstruo();
    }
}