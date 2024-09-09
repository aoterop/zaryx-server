using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface MonstruoMapaDao
    {
        Task<IMonstruoMapa> ObtenerMonstruoMapaPorId(int idMonstruoMapa);
        Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeTodosLosMapas();
        Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeUnMapa(short referenciaMapa);
    }
}