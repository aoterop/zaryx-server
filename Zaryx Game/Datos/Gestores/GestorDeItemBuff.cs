using System.Threading;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemBuff
    {
        private readonly IItemBuffRepository _itemBuffRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemBuff(GestorDeRepos gestorDeRepos)
        {
            _itemBuffRepo = gestorDeRepos.ItemBuffRepo;
        }


        public async Task<ItemBuffDTO> ObtenerItemBuffPorId(int idItemBuff)
        {
            await _semaphore.WaitAsync();

            ItemBuffDTO? itemBuff = null;

            try
            {
                IItemBuff iItemBuff = await _itemBuffRepo.ObtenerItemBuffPorId(idItemBuff); 
                itemBuff = new ItemBuffDTO(iItemBuff);
            }
            finally { _semaphore.Release(); }

            return itemBuff;
        }

        public async Task<List<ItemBuffDTO>> ObtenerItemsBuffPorItem(short itemGenerador)
        {
            await _semaphore.WaitAsync();

            List<ItemBuffDTO> itemsBuffsFinales = new();

            try 
            { 
                List<IItemBuff> itemsBuffs = await _itemBuffRepo.ObtenerItemsBuffPorItem(itemGenerador);

                foreach(var itemBuff in itemsBuffs)
                {
                    itemsBuffsFinales.Add(new ItemBuffDTO(itemBuff));
                }
            }
            finally { _semaphore.Release(); }

            return itemsBuffsFinales;
        }

        public async Task<List<ItemBuffDTO>> ObtenerItemsBuffPorBuff(short buffGenerador)
        {
            await _semaphore.WaitAsync();

            List<ItemBuffDTO> itemsBuffsFinales = new();

            try 
            { 
                List<IItemBuff> itemsBuffs = await _itemBuffRepo.ObtenerItemsBuffPorBuff(buffGenerador);

                foreach(var itemBuff in itemsBuffs)
                {
                    itemsBuffsFinales.Add(new ItemBuffDTO(itemBuff));
                }
            }
            finally { _semaphore.Release(); }

            return itemsBuffsFinales;
        }

        public async Task<List<ItemBuffDTO>> ObtenerTodosLosItemBuff()
        {
            await _semaphore.WaitAsync();

            List<ItemBuffDTO> itemsBuffsFinales = new();

            try
            { 
                List<IItemBuff> itemsBuffs = await _itemBuffRepo.ObtenerTodosLosItemBuff();

                foreach(var itemBuff in itemsBuffs)
                {
                    itemsBuffsFinales.Add(new ItemBuffDTO(itemBuff));
                }
            }
            finally { _semaphore.Release(); }

            return itemsBuffsFinales;
        }
    }
}