using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class TiendaRepository : ITiendaRepository
    {
        private readonly TiendaDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public TiendaRepository(TiendaDao dao) { _dao = dao; }

        public async Task<ITienda> ObtenerTiendaPorId(int idTienda)
        {
            await _semaphore.WaitAsync();

            ITienda tienda = new Tienda();

            try { tienda = await _dao.ObtenerTiendaPorId(idTienda); }
            finally { _semaphore.Release(); }

            return tienda;
        }

        public async Task<List<ITienda>> ObtenerTodasLasTiendas()
        {
            await _semaphore.WaitAsync();

            List<ITienda> tiendas = new();

            try { tiendas = await _dao.ObtenerTodasLasTiendas(); }
            finally { _semaphore.Release(); }

            return tiendas;
        }

        public async Task<List<ITienda>> ObtenerTodasLasTiendasDeUnMapa(short mapaTienda)
        {
            await _semaphore.WaitAsync();

            List<ITienda> tiendas = new();

            try { tiendas = await _dao.ObtenerTodasLasTiendasDeUnMapa(mapaTienda); }
            finally { _semaphore.Release(); }

            return tiendas;
        }

        public ITienda CrearTienda() { return new Tienda(); }
    }
}