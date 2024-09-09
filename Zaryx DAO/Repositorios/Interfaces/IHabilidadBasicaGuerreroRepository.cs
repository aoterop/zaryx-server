using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadBasicaGuerreroRepository : IHabilidadRepository<IHabilidadBasicaGuerrero>
    {
        IHabilidadBasicaGuerrero CrearHabilidadBasicaGuerrero();
    }
}