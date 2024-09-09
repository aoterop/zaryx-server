using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface BuffHabilidadDao
    {
        Task<IBuffHabilidad> ObtenerBuffHabilidad(int idHabilidadBuff);
        Task<List<IBuffHabilidad>> ObtenerTodosLosBuffHabilidad();
        Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorHabilidad(short habilidadAsociada);
        Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorBuff(short buffProducido);
    }
}