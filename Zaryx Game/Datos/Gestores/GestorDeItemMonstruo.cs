using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemMonstruo
    {
        private readonly IItemMonstruoRepository _itemMonstruoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemMonstruo(GestorDeRepos gestorDeRepos)
        {
            _itemMonstruoRepo = gestorDeRepos.ItemMonstruoRepo;
        }

        public async Task<ItemMonstruoDTO> ObtenerItemMonstruoPorId(short idItemMonstruo)
        {
            await _semaphore.WaitAsync();

            ItemMonstruoDTO? itemMonstruo = null;

            try
            { 
                IItemMonstruo iItemMonstruo = await _itemMonstruoRepo.ObtenerItemMonstruoPorId(idItemMonstruo);
                itemMonstruo = new ItemMonstruoDTO(iItemMonstruo);
            }
            finally { _semaphore.Release(); }

            return itemMonstruo;
        }

        public async Task<List<ItemMonstruoDTO>> ObtenerTodosLosItemsDeTodosLosMonstruos()
        {
            await _semaphore.WaitAsync();

            List<ItemMonstruoDTO> itemsMonstruosFinales = new();

            try
            {
                List<IItemMonstruo> itemsMonstruo = await _itemMonstruoRepo.ObtenerTodosLosItemsDeTodosLosMonstruos();

                foreach (var item in itemsMonstruo)
                {
                    itemsMonstruosFinales.Add(new ItemMonstruoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsMonstruosFinales;
        }

        public async Task<List<ItemMonstruoDTO>> ObtenerTodosLosItemsDeUnMonstruo(short monstruoArrojador)
        {
            await _semaphore.WaitAsync();

            List<ItemMonstruoDTO> itemsMonstruosFinales = new();

            try 
            { 
                List<IItemMonstruo> itemsMonstruo = await _itemMonstruoRepo.ObtenerTodosLosItemsDeUnMonstruo(monstruoArrojador);

                foreach(var item in itemsMonstruo)
                {
                    itemsMonstruosFinales.Add(new ItemMonstruoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsMonstruosFinales;
        }
    }
}