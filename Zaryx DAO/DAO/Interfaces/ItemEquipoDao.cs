using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface ItemEquipoDao<T> : ItemDao<T> where T : IItemEquipo
    {
    }
}