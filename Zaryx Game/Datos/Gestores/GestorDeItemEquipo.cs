using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeItemEquipo
    {
        private readonly IItemEquipoRepository<IItemEquipo> _itemEquipoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeItemEquipo(GestorDeRepos gestorDeRepos)
        {
            _itemEquipoRepo = gestorDeRepos.ItemEquipoRepo;
        }

        public async Task<ItemEquipoDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            ItemEquipoDTO? item = null;

            try
            {
                IItemEquipo iItem = await _itemEquipoRepo.ObtenerItemPorId(idItem);
                item = new ItemEquipoDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<ItemEquipoDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<ItemEquipoDTO> itemsFinales = new();

            try
            {
                List<IItemEquipo> items = await _itemEquipoRepo.ObtenerTodosLosItems(); 

                foreach(var item in items)
                {
                    itemsFinales.Add(new ItemEquipoDTO(item));
                }
            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}