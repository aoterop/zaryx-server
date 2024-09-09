using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface ITiendaRepository
    {
        Task<ITienda> ObtenerTiendaPorId(int idTienda);
        Task<List<ITienda>> ObtenerTodasLasTiendas();
        Task<List<ITienda>> ObtenerTodasLasTiendasDeUnMapa(short mapaTienda);
        ITienda CrearTienda();
    }
}