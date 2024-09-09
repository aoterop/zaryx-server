using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemTiendaRepository : IItemTiendaRepository
    {
        private readonly ItemTiendaDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemTiendaRepository(ItemTiendaDao dao) { _dao = dao; }

        public async Task<IItemTienda> ObtenerItemDeTiendaPorId(int idItemTienda)
        {
            await _semaphore.WaitAsync();

            IItemTienda itemTienda = new ItemTienda();

            try { itemTienda = await _dao.ObtenerItemDeTiendaPorId(idItemTienda); }
            finally { _semaphore.Release(); }

            return itemTienda;
        }

        public async Task<List<IItemTienda>> ObtenerTodosLosItemsDeTodasLasTiendas()
        {
            await _semaphore.WaitAsync();

            List<IItemTienda> itemsTiendas = new();

            try { itemsTiendas = await _dao.ObtenerTodosLosItemsDeTodasLasTiendas(); }
            finally { _semaphore.Release(); }

            return itemsTiendas;
        }

        public async Task<List<IItemTienda>> ObtenerTodosLosItemsDeUnaTienda(int puestoDeVenta)
        {
            await _semaphore.WaitAsync();

            List<IItemTienda> itemsTienda = new();

            try { itemsTienda = await _dao.ObtenerTodosLosItemsDeUnaTienda(puestoDeVenta); }
            finally { _semaphore.Release(); }

            return itemsTienda;
        }

        public IItemTienda CrearItemTienda() { return new ItemTienda(); }
    }
}