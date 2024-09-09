using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemEquipoDefensivo
    {
        private readonly IItemEquipoDefensivoRepository _itemEquipoDefensivoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemEquipoDefensivo(GestorDeRepos gestorDeRepos)
        {
            _itemEquipoDefensivoRepo = gestorDeRepos.ItemEquipoDefensivoRepo;
        }

        public async Task<ItemEquipoDefensivoDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemEquipoDefensivoDTO? item = null;

            try 
            { 
                IItemEquipoDefensivo iItem = await _itemEquipoDefensivoRepo.ObtenerItemPorId(idItem);
                item = new ItemEquipoDefensivoDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemEquipoDefensivoDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemEquipoDefensivoDTO> itemsFinales = new();

            try 
            { 
                List<IItemEquipoDefensivo> items = await _itemEquipoDefensivoRepo.ObtenerTodosLosItems();

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemEquipoDefensivoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}