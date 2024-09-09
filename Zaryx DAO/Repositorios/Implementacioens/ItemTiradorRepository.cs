using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemTiradorRepository : IItemTiradorRepository
    {
        private readonly ItemTiradorDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemTiradorRepository(ItemTiradorDao dao) { _dao = dao; }

        public async Task<long> CrearItemTirador(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            await _semaphore.WaitAsync();

            long idItem = -1;

            try { idItem = await _dao.CrearItemTirador(propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario); }
            finally { _semaphore.Release(); }

            return idItem;
        }

        public async Task<bool> EliminarItemTirador(long idItemTirador)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarItemTirador(idItemTirador); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public async Task<bool> ActualizarItemTirador(IItemTirador itemTirador)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _dao.ActualizarItemTirador(itemTirador); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<List<IItemTirador>> ObtenerTodosLosItemsDeTodosLosTiradores()
        {
            await _semaphore.WaitAsync();

            List<IItemTirador> itemsTiradores = new();

            try { itemsTiradores = await _dao.ObtenerTodosLosItemsDeTodosLosTiradores(); }
            finally { _semaphore.Release(); }

            return itemsTiradores;
        }

        public async Task<List<IItemTirador>> ObtenerTodosLosItemsDeUnTirador(long propietario)
        {
            await _semaphore.WaitAsync();

            List<IItemTirador> itemsTirador = new();

            try { itemsTirador = await _dao.ObtenerTodosLosItemsDeUnTirador(propietario); }
            finally { _semaphore.Release(); }

            return itemsTirador;
        }

        public IItemTirador CrearItemTirador() { return new ItemTirador(); }
    }
}