using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IPortalRepository
    {
        Task<IPortal> ObtenerPortalPorId(int idPortal);
        Task<List<IPortal>> ObtenerTodosLosPortales();
        Task<List<IPortal>> ObtenerTodosLosPortalesDeUnMapa(short mapaOrigen);
        IPortal CrearPortal();
    }
}