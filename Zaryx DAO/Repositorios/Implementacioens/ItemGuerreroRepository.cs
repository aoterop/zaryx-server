using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemGuerreroRepository : IItemGuerreroRepository
    {
        private readonly ItemGuerreroDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemGuerreroRepository(ItemGuerreroDao dao) { _dao = dao; }

        public async Task<long> CrearItemGuerrero(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            await _semaphore.WaitAsync();

            long idItem = -1;

            try { idItem = await _dao.CrearItemGuerrero(propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario); }
            finally { _semaphore.Release(); }

            return idItem;
        }

        public async Task<bool> EliminarItemGuerrero(long idItemGuerrero)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarItemGuerrero(idItemGuerrero); }
            finally { _semaphore.Release(); }

            return eliminado;
        }


        public async Task<bool> ActualizarItemGuerrero(IItemGuerrero itemGuerrero)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _dao.ActualizarItemGuerrero(itemGuerrero); }
            finally { _semaphore.Release(); }

            return actualizado;
        }


        public async Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeTodosLosGuerreros()
        {
            await _semaphore.WaitAsync();

            List<IItemGuerrero> itemsGuerreros = new();

            try { itemsGuerreros = await _dao.ObtenerTodosLosItemsDeTodosLosGuerreros(); }
            finally { _semaphore.Release(); }

            return itemsGuerreros;
        }

        public async Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeUnGuerrero(long propietario)
        {
            await _semaphore.WaitAsync();

            List<IItemGuerrero> itemsGuerrero = new();

            try { itemsGuerrero = await _dao.ObtenerTodosLosItemsDeUnGuerrero(propietario); }
            finally { _semaphore.Release(); }

            return itemsGuerrero;
        }

        public IItemGuerrero CrearItemGuerrero() { return new ItemGuerrero(); }
    }
}