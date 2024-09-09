using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IBuffRepository
    {
        Task<IBuff> ObtenerBuffPorId(short idBuff);
        Task<List<IBuff>> ObtenerTodosLosBuff();
        IBuff CrearBuff();
    }
}