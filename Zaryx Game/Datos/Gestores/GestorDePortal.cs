using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDePortal
    {
        private readonly IPortalRepository _portalRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDePortal(GestorDeRepos gestorDeRepos)
        {
            _portalRepo = gestorDeRepos.PortalRepo;
        }

        public async Task<PortalDTO> ObtenerPortalPorId(int idPortal)
        {
            await _semaphore.WaitAsync();

            PortalDTO? portal = null;

            try 
            {
                IPortal iPortal = await _portalRepo.ObtenerPortalPorId(idPortal);
                portal = new PortalDTO(iPortal);
            }
            finally { _semaphore.Release(); }

            return portal;
        }

        public async Task<List<PortalDTO>> ObtenerTodosLosPortales()
        {
            await _semaphore.WaitAsync();

            List<PortalDTO> portalesFinales = new();

            try
            { 
                List<IPortal> portales = await _portalRepo.ObtenerTodosLosPortales();

                foreach (var portal in portales)
                {
                    portalesFinales.Add(new PortalDTO(portal));
                }
            }
            finally { _semaphore.Release(); }

            return portalesFinales;
        }

        public async Task<List<PortalDTO>> ObtenerTodosLosPortalesDeUnMapa(short mapaOrigen)
        {
            await _semaphore.WaitAsync();

            List<PortalDTO> portalesFinales = new();

            try
            {
                List<IPortal> portales = await _portalRepo.ObtenerTodosLosPortalesDeUnMapa(mapaOrigen);
                
                foreach (var portal in portales)
                {
                    portalesFinales.Add(new PortalDTO(portal));
                }
            }
            finally { _semaphore.Release(); }

            return portalesFinales;
        }
    }
}