using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemEquipoOfensivo
    {
        private readonly IItemEquipoOfensivoRepository _itemEquipoOfensivoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemEquipoOfensivo(GestorDeRepos gestorDeRepos)
        {
            _itemEquipoOfensivoRepo = gestorDeRepos.ItemEquipoOfensivoRepo;
        }

        public async Task<ItemEquipoOfensivoDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemEquipoOfensivoDTO? item = null;

            try
            {
                IItemEquipoOfensivo iItem = await _itemEquipoOfensivoRepo.ObtenerItemPorId(idItem);
                item = new ItemEquipoOfensivoDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemEquipoOfensivoDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemEquipoOfensivoDTO> itemsFinales = new();

            try
            {
                List<IItemEquipoOfensivo> items = await _itemEquipoOfensivoRepo.ObtenerTodosLosItems(); 

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemEquipoOfensivoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}