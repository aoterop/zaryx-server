using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemBuffRepository : IItemBuffRepository
    {
        private readonly ItemBuffDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemBuffRepository(ItemBuffDao dao) { _dao = dao; }

        public async Task<IItemBuff> ObtenerItemBuffPorId(int idItemBuff)
        {
            await _semaphore.WaitAsync();

            IItemBuff itemBuff = new ItemBuff();

            try { itemBuff = await _dao.ObtenerItemBuffPorId(idItemBuff); }
            finally { _semaphore.Release(); }

            return itemBuff;
        }

        public async Task<List<IItemBuff>> ObtenerItemsBuffPorItem(short itemGenerador)
        {
            await _semaphore.WaitAsync();

            List<IItemBuff> itemsBuffs = new();

            try { itemsBuffs = await _dao.ObtenerItemsBuffPorItem(itemGenerador); }
            finally { _semaphore.Release(); }

            return itemsBuffs;
        }

        public async Task<List<IItemBuff>> ObtenerItemsBuffPorBuff(short buffGenerador)
        {
            await _semaphore.WaitAsync();

            List <IItemBuff> itemsBuffs = new();

            try { itemsBuffs = await _dao.ObtenerItemsBuffPorBuff(buffGenerador); }
            finally { _semaphore.Release(); }

            return itemsBuffs;
        }

        public async Task<List<IItemBuff>> ObtenerTodosLosItemBuff()
        {
            await _semaphore.WaitAsync();

            List<IItemBuff> itemsBuffs = new();

            try { itemsBuffs = await _dao.ObtenerTodosLosItemBuff(); }
            finally { _semaphore.Release(); }

            return itemsBuffs;
        }

        public IItemBuff CrearItemBuff() { return new ItemBuff(); }
    }
}