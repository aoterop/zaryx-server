using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemConsumoRepository : IItemRepository<IItemConsumo>
    {
        IItemConsumo CrearItemConsumo();
    }
}