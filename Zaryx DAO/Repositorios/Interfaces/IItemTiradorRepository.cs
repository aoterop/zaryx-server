using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemTiradorRepository
    {
        Task<long> CrearItemTirador(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario);
        Task<bool> EliminarItemTirador(long idItemTirador);
        Task<bool> ActualizarItemTirador(IItemTirador itemTirador);
        Task<List<IItemTirador>> ObtenerTodosLosItemsDeTodosLosTiradores();
        Task<List<IItemTirador>> ObtenerTodosLosItemsDeUnTirador(long propietario);
        IItemTirador CrearItemTirador();
    }
}