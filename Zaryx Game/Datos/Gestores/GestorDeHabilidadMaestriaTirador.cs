using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadMaestriaTirador
    {
        private readonly IHabilidadMaestriaTiradorRepository _habilidadMaestriaTiradorRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadMaestriaTirador(GestorDeRepos gestorDeRepos)
        {
            _habilidadMaestriaTiradorRepo = gestorDeRepos.HabilidadMaestriaTiradorRepo;
        }

        public async Task<HabilidadMaestriaTiradorDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadMaestriaTiradorDTO? habilidad = null;

            try
            {
                IHabilidadMaestriaTirador iHabilidad = await _habilidadMaestriaTiradorRepo.ObtenerHabilidadPorId(idHabilidad);
                habilidad = new HabilidadMaestriaTiradorDTO(iHabilidad);
            }

            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadMaestriaTiradorDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadMaestriaTiradorDTO> habilidadesFinales = new();

            try
            { 
                List<IHabilidadMaestriaTirador> habilidades = await _habilidadMaestriaTiradorRepo.ObtenerTodasLasHabilidades();

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMaestriaTiradorDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadMaestriaTiradorDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadMaestriaTiradorDTO> habilidadesFinales = new();

            try
            { 
                List<IHabilidadMaestriaTirador> habilidades = await _habilidadMaestriaTiradorRepo.ObtenerHabilidadPorTipo(tipoHabilidad);

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMaestriaTiradorDTO(habilidad));
                }

            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}