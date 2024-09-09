using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class MonstruoMapaRepository : IMonstruoMapaRepository
    {
        private readonly MonstruoMapaDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);
        public MonstruoMapaRepository(MonstruoMapaDao dao) { _dao = dao; }

        public async Task<IMonstruoMapa> ObtenerMonstruoMapaPorId(int idMonstruoMapa)
        {
            await _semaphore.WaitAsync();

            IMonstruoMapa monstruoMapa = new MonstruoMapa();

            try { monstruoMapa = await _dao.ObtenerMonstruoMapaPorId(idMonstruoMapa); }
            finally { _semaphore.Release(); }

            return monstruoMapa;
        }

        public async Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeTodosLosMapas()
        {
            await _semaphore.WaitAsync();

            List<IMonstruoMapa> monstruosMapas = new();

            try { monstruosMapas = await _dao.ObtenerTodosLosMonstruosDeTodosLosMapas(); }
            finally { _semaphore.Release(); }

            return monstruosMapas;
        }

        public async Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeUnMapa(short referenciaMapa)
        {
            await _semaphore.WaitAsync();

            List<IMonstruoMapa> monstruosMapa = new();

            try { monstruosMapa = await _dao.ObtenerTodosLosMonstruosDeUnMapa(referenciaMapa); }
            finally { _semaphore.Release(); }

            return monstruosMapa;
        }

        public IMonstruoMapa CrearMonstruoMapa() { return new MonstruoMapa(); }
    }
}