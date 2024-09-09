using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemEquipoRepository : IItemEquipoRepository<IItemEquipo>
    {
        private readonly ItemEquipoDao<IItemEquipo> _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemEquipoRepository(ItemEquipoDao<IItemEquipo> dao) { _dao = dao; }

        public async Task<IItemEquipo> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IItemEquipo item = new ItemEquipo();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItemEquipo>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItemEquipo> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }
    }
}