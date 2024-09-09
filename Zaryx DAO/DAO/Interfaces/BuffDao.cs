using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface BuffDao
    {
        Task<IBuff> ObtenerBuffPorId(short idBuff);
        Task<List<IBuff>> ObtenerTodosLosBuff();
    }
}