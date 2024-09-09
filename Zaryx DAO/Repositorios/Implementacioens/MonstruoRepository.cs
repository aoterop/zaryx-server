using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class MonstruoRepository : IMonstruoRepository
    {
        private readonly MonstruoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public MonstruoRepository(MonstruoDao dao) { _dao = dao; }

        public async Task<IMonstruo> ObtenerMonstruoPorId(short idMonstruo)
        {
            await _semaphore.WaitAsync();

            IMonstruo monstruo = new Monstruo();

            try { monstruo = await _dao.ObtenerMonstruoPorId(idMonstruo); }
            finally { _semaphore.Release(); }

            return monstruo;
        }

        public async Task<List<IMonstruo>> ObtenerTodosLosMonstruos()
        {
            await _semaphore.WaitAsync();

            List<IMonstruo> monstruos = new();

            try { monstruos = await _dao.ObtenerTodosLosMonstruos(); }
            finally { _semaphore.Release(); }

            return monstruos;
        }

        public IMonstruo CrearMonstruo() { return new Monstruo(); }
    }
}