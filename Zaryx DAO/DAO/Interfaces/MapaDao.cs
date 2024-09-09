using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface MapaDao
    {
        Task<IMapa> ObtenerMapaPorId(short idMapa);
        Task<List<IMapa>> ObtenerTodosLosMapas();
    }
}