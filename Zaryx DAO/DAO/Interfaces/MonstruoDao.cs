using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface MonstruoDao
    {
        Task<IMonstruo> ObtenerMonstruoPorId(short idMonstruo);
        Task<List<IMonstruo>> ObtenerTodosLosMonstruos();
    }
}