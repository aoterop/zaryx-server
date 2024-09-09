using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class MapaRepository : IMapaRepository
    {
        private readonly MapaDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public MapaRepository(MapaDao dao) { _dao = dao; }

        public async Task<IMapa> ObtenerMapaPorId(short idMapa)
        {
            await _semaphore.WaitAsync();

            IMapa mapa = new Mapa();

            try { mapa = await _dao.ObtenerMapaPorId(idMapa); }
            finally { _semaphore.Release(); }

            return mapa;
        }

        public async Task<List<IMapa>> ObtenerTodosLosMapas()
        {
            await _semaphore.WaitAsync();

            List<IMapa> mapas = new();

            try { mapas = await _dao.ObtenerTodosLosMapas(); }
            finally { _semaphore.Release(); }

            return mapas;
        }

        public IMapa CrearMapa() { return new Mapa(); }
    }
}