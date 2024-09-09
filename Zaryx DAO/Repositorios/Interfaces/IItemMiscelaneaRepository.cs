using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemMiscelaneaRepository : IItemRepository<IItemMiscelanea>
    {
        IItemMiscelanea CrearItemMiscelanea();
    }
}