using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IMonstruoMapaRepository
    {
        Task<IMonstruoMapa> ObtenerMonstruoMapaPorId(int idMonstruoMapa);
        Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeTodosLosMapas();
        Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeUnMapa(short referenciaMapa);
        IMonstruoMapa CrearMonstruoMapa();
    }
}