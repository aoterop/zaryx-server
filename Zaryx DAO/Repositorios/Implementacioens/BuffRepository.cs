using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class BuffRepository : IBuffRepository
    {
        private readonly BuffDao _dao;
        private readonly SemaphoreSlim _semaphore = new(1);

        public BuffRepository(BuffDao dao) { _dao = dao; }

        public async Task<IBuff> ObtenerBuffPorId(short idBuff)
        {
            await _semaphore.WaitAsync();

            IBuff buff = new Buff();

            try
            {
                buff = await _dao.ObtenerBuffPorId(idBuff);
            }
            finally
            {
                _semaphore.Release();
            }
   
            return buff;
        }

        public async Task<List<IBuff>> ObtenerTodosLosBuff()
        {
            await _semaphore.WaitAsync();

            List<IBuff> buffs = new();
            try
            {
                buffs = await _dao.ObtenerTodosLosBuff();
            }
            finally
            {
                _semaphore.Release();
            }
            return buffs;
        }

        public IBuff CrearBuff() { return new Buff(); }
    }
}