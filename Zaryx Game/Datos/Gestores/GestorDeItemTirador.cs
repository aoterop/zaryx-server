using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemTirador
    {
        private readonly IItemTiradorRepository _itemTiradorRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemTirador(GestorDeRepos gestorDeRepos)
        {
            _itemTiradorRepo = gestorDeRepos.ItemTiradorRepo;
        }

        public async Task<long> CrearItemTirador(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            await _semaphore.WaitAsync();

            long idItem = -1;

            try { idItem = await _itemTiradorRepo.CrearItemTirador(propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario); }
            finally { _semaphore.Release(); }

            return idItem;
        }

        public async Task<bool> EliminarItemTirador(long idItemTirador)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _itemTiradorRepo.EliminarItemTirador(idItemTirador); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public async Task<bool> ActualizarItemTirador(IItemTirador itemTirador)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _itemTiradorRepo.ActualizarItemTirador(itemTirador); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<List<ItemTiradorDTO>> ObtenerTodosLosItemsDeTodosLosTiradores()
        {
            await _semaphore.WaitAsync();

            List<ItemTiradorDTO> itemsTiradoresFinales = new();

            try
            { 
                List<IItemTirador> itemsTiradores = await _itemTiradorRepo.ObtenerTodosLosItemsDeTodosLosTiradores();

                foreach(var item in itemsTiradores)
                {
                    itemsTiradoresFinales.Add(new ItemTiradorDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsTiradoresFinales;
        }

        public async Task<List<ItemTiradorDTO>> ObtenerTodosLosItemsDeUnTirador(long propietario)
        {
            await _semaphore.WaitAsync();

            List<ItemTiradorDTO> itemsTiradoresFinales = new();

            try
            {
                List<IItemTirador> itemsTiradores = await _itemTiradorRepo.ObtenerTodosLosItemsDeUnTirador(propietario);

                foreach (var item in itemsTiradores)
                {
                    itemsTiradoresFinales.Add(new ItemTiradorDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsTiradoresFinales;
        }
    }
}