using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemConsumoRepository : IItemConsumoRepository
    {
        private readonly ItemConsumoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemConsumoRepository(ItemConsumoDao dao) { _dao = dao; }

        public async Task<IItemConsumo> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IItemConsumo item = new ItemConsumo();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItemConsumo>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItemConsumo> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IItemConsumo CrearItemConsumo() { return new ItemConsumo(); }
    }
}