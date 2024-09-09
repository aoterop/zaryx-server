using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadBasicaGuerrero
    {
        private readonly IHabilidadBasicaGuerreroRepository _habilidadBasicaGuerreroRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadBasicaGuerrero(GestorDeRepos gestorDeRepos)
        {
            _habilidadBasicaGuerreroRepo = gestorDeRepos.HabilidadBasicaGuerreroRepo;
        }

        public async Task<HabilidadBasicaGuerreroDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadBasicaGuerreroDTO? habilidad = null;

            try 
            { 
                IHabilidadBasicaGuerrero iHabilidad = await _habilidadBasicaGuerreroRepo.ObtenerHabilidadPorId(idHabilidad);
                habilidad = new HabilidadBasicaGuerreroDTO(iHabilidad);
            }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadBasicaGuerreroDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaGuerreroDTO> habilidadesFinales = new();

            try
            {
                List<IHabilidadBasicaGuerrero> habilidades = await _habilidadBasicaGuerreroRepo.ObtenerTodasLasHabilidades();
                    
                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaGuerreroDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }


        public async Task<List<HabilidadBasicaGuerreroDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaGuerreroDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaGuerrero> habilidades = await _habilidadBasicaGuerreroRepo.ObtenerHabilidadPorTipo(tipoHabilidad);

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaGuerreroDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}