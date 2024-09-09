using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadBasicaTirador
    {
        private readonly IHabilidadBasicaTiradorRepository _habilidadBasicaTiradorRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadBasicaTirador(GestorDeRepos gestorDeRepos)
        {
            _habilidadBasicaTiradorRepo = gestorDeRepos.HabilidadBasicaTiradorRepo;
        }

        public async Task<HabilidadBasicaTiradorDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadBasicaTiradorDTO? habilidad = null;

            try 
            { 
                IHabilidadBasicaTirador iHabilidad = await _habilidadBasicaTiradorRepo.ObtenerHabilidadPorId(idHabilidad);
                habilidad = new HabilidadBasicaTiradorDTO(iHabilidad);
            }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadBasicaTiradorDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaTiradorDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaTirador> habilidades = await _habilidadBasicaTiradorRepo.ObtenerTodasLasHabilidades(); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaTiradorDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadBasicaTiradorDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaTiradorDTO> habilidadesFinales = new();

            try 
            {
                List<IHabilidadBasicaTirador> habilidades = await _habilidadBasicaTiradorRepo.ObtenerHabilidadPorTipo(tipoHabilidad); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaTiradorDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}