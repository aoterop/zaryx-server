using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemRepository : IItemRepository<IItem>
    {
        private readonly ItemDao<IItem> _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemRepository(ItemDao<IItem> dao) { _dao = dao; }

        public async Task<IItem> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IItem item = new Item();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItem>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItem> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }
    }
}