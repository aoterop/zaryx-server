using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemTiendaRepository
    {
        Task<IItemTienda> ObtenerItemDeTiendaPorId(int idItemTienda);
        Task<List<IItemTienda>> ObtenerTodosLosItemsDeTodasLasTiendas();
        Task<List<IItemTienda>> ObtenerTodosLosItemsDeUnaTienda(int puestoDeVenta);
        IItemTienda CrearItemTienda();
    }
}