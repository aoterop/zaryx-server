using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemEquipoOfensivoRepository : IItemEquipoRepository<IItemEquipoOfensivo>
    {
        IItemEquipoOfensivo CrearItemEquipoOfensivo();
    }
}