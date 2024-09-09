using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemTienda
    {
        private readonly IItemTiendaRepository _itemTiendaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemTienda(GestorDeRepos gestorDeRepos)
        {
            _itemTiendaRepo = gestorDeRepos.ItemTiendaRepo;
        }

        public async Task<ItemTiendaDTO> ObtenerItemDeTiendaPorId(int idItemTienda)
        {
            await _semaphore.WaitAsync();

            ItemTiendaDTO? itemTienda = null;

            try 
            { 
                IItemTienda iItemTienda = await _itemTiendaRepo.ObtenerItemDeTiendaPorId(idItemTienda);
                itemTienda = new ItemTiendaDTO(iItemTienda);
            }
            finally { _semaphore.Release(); }

            return itemTienda;
        }

        public async Task<List<ItemTiendaDTO>> ObtenerTodosLosItemsDeTodasLasTiendas()
        {
            await _semaphore.WaitAsync();

            List<ItemTiendaDTO> itemsTiendasFinales = new();

            try
            { 
                List<IItemTienda> itemsTiendas = await _itemTiendaRepo.ObtenerTodosLosItemsDeTodasLasTiendas();

                foreach(var item in itemsTiendas)
                {
                    itemsTiendasFinales.Add(new ItemTiendaDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsTiendasFinales;
        }

        public async Task<List<ItemTiendaDTO>> ObtenerTodosLosItemsDeUnaTienda(int puestoDeVenta)
        {
            await _semaphore.WaitAsync();

            List<ItemTiendaDTO> itemsTiendasFinales = new();

            try
            {
                List<IItemTienda> itemsTiendas = await _itemTiendaRepo.ObtenerTodosLosItemsDeUnaTienda(puestoDeVenta);

                foreach (var item in itemsTiendas)
                {
                    itemsTiendasFinales.Add(new ItemTiendaDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsTiendasFinales;
        }
    }
}