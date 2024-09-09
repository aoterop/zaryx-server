using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface ItemTiendaDao
    {
        Task<IItemTienda> ObtenerItemDeTiendaPorId(int idItemTienda);
        Task<List<IItemTienda>> ObtenerTodosLosItemsDeTodasLasTiendas();
        Task<List<IItemTienda>> ObtenerTodosLosItemsDeUnaTienda(int puestoDeVenta);
    }
}