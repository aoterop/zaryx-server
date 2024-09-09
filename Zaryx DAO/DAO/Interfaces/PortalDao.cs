using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface PortalDao
    {
        Task<IPortal> ObtenerPortalPorId(int idPortal);
        Task<List<IPortal>> ObtenerTodosLosPortales();
        Task<List<IPortal>> ObtenerTodosLosPortalesDeUnMapa(short mapaOrigen);
    }
}