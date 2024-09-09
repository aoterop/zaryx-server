using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemEquipoOfensivoRepository : IItemEquipoOfensivoRepository
    {
        private readonly ItemEquipoOfensivoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemEquipoOfensivoRepository(ItemEquipoOfensivoDao dao) { _dao = dao; }

        public async Task<IItemEquipoOfensivo> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IItemEquipoOfensivo item = new ItemEquipoOfensivo();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItemEquipoOfensivo>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItemEquipoOfensivo> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IItemEquipoOfensivo CrearItemEquipoOfensivo() { return new ItemEquipoOfensivo(); }
    }
}