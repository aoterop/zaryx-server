using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeMaestriaGuerrero
    {
        private readonly IMaestriaGuerreroRepository _maestriaGuerreroRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeMaestriaGuerrero(GestorDeRepos gestorDeRepos)
        {
            _maestriaGuerreroRepo = gestorDeRepos.MaestriaGuerreroRepo;
        }

        public async Task<MaestriaGuerreroDTO> ObtenerItemPorId(short idItem)
        {
            await _semaphore.WaitAsync();

            MaestriaGuerreroDTO? item = null;

            try 
            {
                IMaestriaGuerrero iItem = await _maestriaGuerreroRepo.ObtenerItemPorId(idItem);
                item = new MaestriaGuerreroDTO(iItem);
            }
            finally { _semaphore.Release(); }

            return item;
        }

        public async Task<List<MaestriaGuerreroDTO>> ObtenerTodosLosItems()
        {
            await _semaphore.WaitAsync();

            List<MaestriaGuerreroDTO> itemsFinales = new();

            try 
            { 
                List<IMaestriaGuerrero> items = await _maestriaGuerreroRepo.ObtenerTodosLosItems();

                foreach(var item in items)
                {
                    itemsFinales.Add(new MaestriaGuerreroDTO(item));
                }

            }
            finally { _semaphore.Release(); }

            return itemsFinales;
        }
    }
}