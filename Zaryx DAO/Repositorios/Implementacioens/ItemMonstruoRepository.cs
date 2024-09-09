using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemMonstruoRepository : IItemMonstruoRepository
    {
        private readonly ItemMonstruoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemMonstruoRepository(ItemMonstruoDao dao) { _dao = dao; }

        public async Task<IItemMonstruo> ObtenerItemMonstruoPorId(short idItemMonstruo)
        {
            await _semaphore.WaitAsync();

            IItemMonstruo itemMonstruo = new ItemMonstruo();

            try { itemMonstruo = await _dao.ObtenerItemMonstruoPorId(idItemMonstruo); }
            finally { _semaphore.Release(); }

            return itemMonstruo;
        }

        public async Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeTodosLosMonstruos()
        {
            await _semaphore.WaitAsync();

            List<IItemMonstruo> itemsMonstruos = new();

            try { itemsMonstruos = await _dao.ObtenerTodosLosItemsDeTodosLosMonstruos(); }
            finally { _semaphore.Release(); }

            return itemsMonstruos;
        }

        public async Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeUnMonstruo(short monstruoArrojador)
        {
            await _semaphore.WaitAsync();

            List<IItemMonstruo> itemsMonstruo = new();

            try { itemsMonstruo = await _dao.ObtenerTodosLosItemsDeUnMonstruo(monstruoArrojador); }
            finally { _semaphore.Release(); }

            return itemsMonstruo;
        }

        public IItemMonstruo CrearItemMonstruo() { return new ItemMonstruo(); }
    }
}