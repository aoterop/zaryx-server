using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface TiendaDao
    {
        Task<ITienda> ObtenerTiendaPorId(int idTienda);
        Task<List<ITienda>> ObtenerTodasLasTiendas();
        Task<List<ITienda>> ObtenerTodasLasTiendasDeUnMapa(short mapaTienda);
    }
}