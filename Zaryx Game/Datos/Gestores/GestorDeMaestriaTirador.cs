using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeMaestriaTirador
    {
        private readonly IMaestriaTiradorRepository _maestriaTiradorRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeMaestriaTirador(GestorDeRepos gestorDeRepos)
        {
            _maestriaTiradorRepo = gestorDeRepos.MaestriaTiradorRepo;
        }

        public async Task<MaestriaTiradorDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            MaestriaTiradorDTO? item = null;

            try 
            { 
                IMaestriaTirador iItem = await _maestriaTiradorRepo.ObtenerItemPorId(idItem);
                item = new MaestriaTiradorDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<MaestriaTiradorDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<MaestriaTiradorDTO> itemsFinales = new();

            try
            {
                List<IMaestriaTirador> items = await _maestriaTiradorRepo.ObtenerTodosLosItems();

                foreach(var item in items)
                {
                    itemsFinales.Add(new MaestriaTiradorDTO(item));
                }
            }

            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}