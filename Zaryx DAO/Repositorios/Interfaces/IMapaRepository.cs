using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IMapaRepository
    {
        Task<IMapa> ObtenerMapaPorId(short idMapa);
        Task<List<IMapa>> ObtenerTodosLosMapas();
        IMapa CrearMapa();
    }
}