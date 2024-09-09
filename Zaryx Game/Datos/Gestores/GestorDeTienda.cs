using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeTienda
    {
        private readonly ITiendaRepository _tiendaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeTienda(GestorDeRepos gestorDeRepos)
        {
            _tiendaRepo = gestorDeRepos.TiendaRepo;
        }

        public async Task<TiendaDTO> ObtenerTiendaPorId(int idTienda)
        {
            await _semaphore.WaitAsync();

            TiendaDTO? tienda = null;

            try 
            { 
                ITienda iTienda = await _tiendaRepo.ObtenerTiendaPorId(idTienda);
                tienda = new TiendaDTO(iTienda);
            }
            finally { _semaphore.Release(); }

            return tienda;
        }

        public async Task<List<TiendaDTO>> ObtenerTodasLasTiendas()
        {
            await _semaphore.WaitAsync();

            List<TiendaDTO> tiendasFinales = new();

            try
            {
                List<ITienda> tiendas = await _tiendaRepo.ObtenerTodasLasTiendas();

                foreach (var tienda in tiendas)
                {
                    tiendasFinales.Add(new TiendaDTO(tienda));
                }
            }
            finally { _semaphore.Release(); }

            return tiendasFinales;
        }

        public async Task<List<TiendaDTO>> ObtenerTodasLasTiendasDeUnMapa(short mapaTienda)
        {
            await _semaphore.WaitAsync();

            List<TiendaDTO> tiendasFinales = new();

            try 
            { 
                List<ITienda> tiendas = await _tiendaRepo.ObtenerTodasLasTiendasDeUnMapa(mapaTienda); 

                foreach(var tienda in tiendas)
                {
                    tiendasFinales.Add(new TiendaDTO(tienda));
                }
            }
            finally { _semaphore.Release(); }

            return tiendasFinales;
        }
    }
}