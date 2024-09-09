using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class PortalRepository : IPortalRepository
    {
        private readonly PortalDao _dao;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public PortalRepository(PortalDao dao) { _dao = dao; }

        public async Task<IPortal> ObtenerPortalPorId(int idPortal)
        {
            await _semaphore.WaitAsync();

            IPortal portal = new Portal();

            try { portal = await _dao.ObtenerPortalPorId(idPortal); }
            finally { _semaphore.Release(); }

            return portal;
        }

        public async Task<List<IPortal>> ObtenerTodosLosPortales()
        {
            await _semaphore.WaitAsync();

            List<IPortal> portales = new();

            try { portales = await _dao.ObtenerTodosLosPortales(); }
            finally { _semaphore.Release(); }

            return portales;
        }

        public async Task<List<IPortal>> ObtenerTodosLosPortalesDeUnMapa(short mapaOrigen)
        {
            await _semaphore.WaitAsync();

            List<IPortal> portales = new();

            try { portales = await _dao.ObtenerTodosLosPortalesDeUnMapa(mapaOrigen); }
            finally { _semaphore.Release(); }

            return portales;
        }

        public IPortal CrearPortal() { return new Portal(); }
    }
}