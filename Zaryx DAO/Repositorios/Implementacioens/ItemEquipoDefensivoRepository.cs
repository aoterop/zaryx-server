using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ItemEquipoDefensivoRepository : IItemEquipoDefensivoRepository
    {
        private readonly ItemEquipoDefensivoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public ItemEquipoDefensivoRepository(ItemEquipoDefensivoDao dao) { _dao = dao; }

        public async Task<IItemEquipoDefensivo> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            IItemEquipoDefensivo item = new ItemEquipoDefensivo();

            try { item = await _dao.ObtenerItemPorId(idItem); }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<IItemEquipoDefensivo>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<IItemEquipoDefensivo> items = new();

            try { items = await _dao.ObtenerTodosLosItems(); }
            finally { _semaphore.Release(); }

            return items;
        }

        public IItemEquipoDefensivo CrearItemEquipoDefensivo() { return new ItemEquipoDefensivo(); }
    }
}