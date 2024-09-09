using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface HabilidadDao<T> where T : IHabilidad
    {
        Task<T> ObtenerHabilidadPorId(short idHabilidad);
        Task<List<T>> ObtenerTodasLasHabilidades();
        Task<List<T>> ObtenerHabilidadPorTipo(byte tipoHabilidad);
    }
}