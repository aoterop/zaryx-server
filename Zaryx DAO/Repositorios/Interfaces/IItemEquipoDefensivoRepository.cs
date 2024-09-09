using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemEquipoDefensivoRepository : IItemEquipoRepository<IItemEquipoDefensivo>
    {
        public IItemEquipoDefensivo CrearItemEquipoDefensivo();
    }
}