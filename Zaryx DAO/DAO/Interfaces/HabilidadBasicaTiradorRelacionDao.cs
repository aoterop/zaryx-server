using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface HabilidadBasicaTiradorRelacionDao
    {
        Task<IHabilidadBasicaTiradorRelacion> ObtenerHabilidadBasicaTiradorRelacionPorId(int idHabilidadTirador);
        Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorTirador(long refTirador);
        Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(short habilidadAdquirida);
        Task<bool> CrearHabilidadBasicaTiradorRelacion(long refTirador, short habilidadAdquirida);
        Task<bool> EliminarHabilidadBasicaTiradorRelacion(int idHabilidadTirador);
    }
}