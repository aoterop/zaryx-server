using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadRepository<T> where T : IHabilidad
    {
        Task<T> ObtenerHabilidadPorId(short idHabilidad);
        Task<List<T>> ObtenerTodasLasHabilidades();
        Task<List<T>> ObtenerHabilidadPorTipo(byte tipoHabilidad);
    }
}