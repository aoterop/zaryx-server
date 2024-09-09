using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class MaestriaGuerreroRepository : IMaestriaGuerreroRepository
    {
        private readonly MaestriaGuerreroDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public MaestriaGuerreroRepository(MaestriaGuerreroDao dao) { _dao = dao; }

        public async Task<IMaestriaGuerrero> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IMaestriaGuerrero item = new MaestriaGuerrero();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IMaestriaGuerrero>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IMaestriaGuerrero> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IItem CrearItem() { return new MaestriaGuerrero(); }
    }
}