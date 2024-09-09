using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadMaestriaGuerrero
    {
        private readonly IHabilidadMaestriaGuerreroRepository _habilidadMaestriaGuerreroRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadMaestriaGuerrero(GestorDeRepos gestorDeRepos)
        {
            _habilidadMaestriaGuerreroRepo = gestorDeRepos.HabilidadMaestriaGuerreroRepo;
        }

        public async Task<HabilidadMaestriaGuerreroDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadMaestriaGuerreroDTO? habilidad = null;

            try 
            { 
                IHabilidadMaestriaGuerrero iHabilidad = await _habilidadMaestriaGuerreroRepo.ObtenerHabilidadPorId(idHabilidad);
                habilidad = new HabilidadMaestriaGuerreroDTO(iHabilidad);
            }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadMaestriaGuerreroDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadMaestriaGuerreroDTO> habilidadesFinales = new();

            try
            { 
                List<IHabilidadMaestriaGuerrero> habilidades = await _habilidadMaestriaGuerreroRepo.ObtenerTodasLasHabilidades();

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMaestriaGuerreroDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadMaestriaGuerreroDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadMaestriaGuerreroDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadMaestriaGuerrero> habilidades = await _habilidadMaestriaGuerreroRepo.ObtenerHabilidadPorTipo(tipoHabilidad); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMaestriaGuerreroDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}