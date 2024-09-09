using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemMiscelanea
    {
        private readonly IItemMiscelaneaRepository _itemMiscelaneaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemMiscelanea(GestorDeRepos gestorDeRepos)
        {
            _itemMiscelaneaRepo = gestorDeRepos.ItemMiscelaneaRepo;
        }

        public async Task<ItemMiscelaneaDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemMiscelaneaDTO? item = null;

            try 
            {
                IItemMiscelanea iItem = await _itemMiscelaneaRepo.ObtenerItemPorId(idItem);
                item = new ItemMiscelaneaDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemMiscelaneaDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemMiscelaneaDTO> itemsFinales = new();

            try
            {
                List<IItemMiscelanea> items = await _itemMiscelaneaRepo.ObtenerTodosLosItems(); 

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemMiscelaneaDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}