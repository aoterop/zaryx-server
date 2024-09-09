using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadMaestriaGuerreroRepository : IHabilidadRepository<IHabilidadMaestriaGuerrero>
    {
        IHabilidadMaestriaGuerrero CrearHabilidadMaestriaGuerrero();
    }
}