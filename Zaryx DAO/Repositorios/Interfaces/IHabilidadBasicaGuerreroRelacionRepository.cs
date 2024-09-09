using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadBasicaGuerreroRelacionRepository
    {
        Task<IHabilidadBasicaGuerreroRelacion> ObtenerHabilidadBasicaGuerreroRelacionPorId(int idHabilidadGuerrero);
        Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(long refGuerrero);
        Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(short habilidadAprendida);
        Task<bool> CrearHabilidadBasicaGuerreroRelacion(long refGuerrero, short habilidadAprendida);
        Task<bool> EliminarHabilidadBasicaGuerreroRelacion(int idHabilidadGuerrero);
        IHabilidadBasicaGuerreroRelacion CrearHabilidadBasicaGuerreroRelacion();
    }
}