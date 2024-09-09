using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemMiscelaneaRepository : IItemMiscelaneaRepository
    {
        private readonly ItemMiscelaneaDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemMiscelaneaRepository(ItemMiscelaneaDao dao) { _dao = dao; }

        public async Task<IItemMiscelanea> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

           IItemMiscelanea item = new ItemMiscelanea();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItemMiscelanea>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItemMiscelanea> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IItemMiscelanea CrearItemMiscelanea() { return new ItemMiscelanea(); }
    }
}