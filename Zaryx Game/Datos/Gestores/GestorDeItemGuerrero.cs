using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Juego.Modelos.Items.Guerrero;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemGuerrero
    {
        private readonly IItemGuerreroRepository _itemGuerreroRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemGuerrero(GestorDeRepos gestorDeRepos)
        {
            _itemGuerreroRepo = gestorDeRepos.ItemGuerreroRepo;
        }

        public async Task<long> CrearItemGuerrero(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            await _semaphore.WaitAsync();

            long idItem = -1;

            try { idItem = await _itemGuerreroRepo.CrearItemGuerrero(propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario); }
            finally { _semaphore.Release(); }

            return idItem;
        }

        public async Task<bool> EliminarItemGuerrero(long idItemGuerrero)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _itemGuerreroRepo.EliminarItemGuerrero(idItemGuerrero); }
            finally { _semaphore.Release(); }

            return eliminado;
        }


        public async Task<bool> ActualizarItemGuerrero(IItemGuerrero itemGuerrero)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _itemGuerreroRepo.ActualizarItemGuerrero(itemGuerrero); }
            finally { _semaphore.Release(); }

            return actualizado;
        }


        public async Task<List<ItemGuerreroDTO>> ObtenerTodosLosItemsDeTodosLosGuerreros()
        {
            await _semaphore.WaitAsync();

            List<ItemGuerreroDTO> itemsGuerrerosFinales = new();

            try
            { 
                List<IItemGuerrero> itemsGuerreros = await _itemGuerreroRepo.ObtenerTodosLosItemsDeTodosLosGuerreros(); 

                foreach(var item in itemsGuerreros)
                {
                    itemsGuerrerosFinales.Add(new ItemGuerreroDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsGuerrerosFinales;
        }

        public async Task<List<ItemGuerreroDTO>> ObtenerTodosLosItemsDeUnGuerrero(long propietario)
        {
            await _semaphore.WaitAsync();

            List<ItemGuerreroDTO> itemsGuerrerosFinales = new();

            try
            {
                List<IItemGuerrero> itemsGuerreros = await _itemGuerreroRepo.ObtenerTodosLosItemsDeUnGuerrero(propietario);

                foreach (var item in itemsGuerreros)
                {
                    itemsGuerrerosFinales.Add(new ItemGuerreroDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsGuerrerosFinales;
        }

        public IItemGuerrero CrearItemGuerrero()
        {
            return _itemGuerreroRepo.CrearItemGuerrero();
        }
    }
}