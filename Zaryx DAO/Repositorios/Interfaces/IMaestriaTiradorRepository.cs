using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IMaestriaTiradorRepository : IItemRepository<  IMaestriaTirador>
    {
        IMaestriaTirador CrearMaestriaTirador();
    }
}