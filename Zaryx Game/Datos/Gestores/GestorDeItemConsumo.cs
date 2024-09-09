using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemConsumo
    {
        private readonly IItemConsumoRepository _itemConsumoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemConsumo(GestorDeRepos gestorDeRepos)
        {
            _itemConsumoRepo = gestorDeRepos.ItemConsumoRepo;
        }

        public async Task<ItemConsumoDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemConsumoDTO? item = null;

            try 
            {
                IItemConsumo iItem = await _itemConsumoRepo.ObtenerItemPorId(idItem);
                item = new ItemConsumoDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemConsumoDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemConsumoDTO> itemsFinales = new();

            try
            { 
                List<IItemConsumo> items = await _itemConsumoRepo.ObtenerTodosLosItems(); 

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemConsumoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}
