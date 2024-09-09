using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class MaestriaTiradorRepository : IMaestriaTiradorRepository
    {
        private readonly MaestriaTiradorDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public MaestriaTiradorRepository(MaestriaTiradorDao dao) { _dao = dao; }

        public async Task<IMaestriaTirador> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IMaestriaTirador item = new MaestriaTirador();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IMaestriaTirador>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IMaestriaTirador> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IMaestriaTirador CrearMaestriaTirador() { return new MaestriaTirador(); }
    }
}