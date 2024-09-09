using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemEquipoRepository<T> : IItemRepository<T> where T : IItemEquipo
    {
    }
}