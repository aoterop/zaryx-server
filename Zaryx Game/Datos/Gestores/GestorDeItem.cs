using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItem
    {
        private readonly IItemRepository<IItem> _itemRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItem(GestorDeRepos gestorDeRepos)
        {
            _itemRepo = gestorDeRepos.ItemRepo;
        }

        public async Task<ItemDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemDTO? item = null;

            try 
            { 
                IItem iItem = await _itemRepo.ObtenerItemPorId(idItem);
                item = new ItemDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemDTO> itemsFinales = new();

            try
            { 
                List<IItem> items = await _itemRepo.ObtenerTodosLosItems();

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}