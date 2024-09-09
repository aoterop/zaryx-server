using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidad
    {
        private readonly IHabilidadRepository<IHabilidad> _habilidadRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidad(GestorDeRepos gestorDeRepos)
        {
            _habilidadRepo = gestorDeRepos.HabilidadRepo;
        }

        public async Task<HabilidadDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadDTO? habilidad = null;

            try 
            {
                IHabilidad iHabilidad = await _habilidadRepo.ObtenerHabilidadPorId(idHabilidad); 
                habilidad = new HabilidadDTO(iHabilidad);
            }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidad> habilidades = await _habilidadRepo.ObtenerTodasLasHabilidades(); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidad> habilidades = await _habilidadRepo.ObtenerHabilidadPorTipo(tipoHabilidad);
                
                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}