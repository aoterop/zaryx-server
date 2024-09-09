using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadMonstruoRepository : IHabilidadRepository<IHabilidadMonstruo>
    {
        IHabilidadMonstruo CrearHabilidadMonstruo();
    }
}