using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadMonstruo
    {
        private readonly IHabilidadMonstruoRepository _habilidadMonstruoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadMonstruo(GestorDeRepos gestorDeRepos)
        {
            _habilidadMonstruoRepo = gestorDeRepos.HabilidadMonstruoRepo;
        }

        public async Task<HabilidadMonstruoDTO> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            HabilidadMonstruoDTO? habilidad = null;

            try
            { 
                IHabilidadMonstruo ihabilidad = await _habilidadMonstruoRepo.ObtenerHabilidadPorId(idHabilidad);
                habilidad = new HabilidadMonstruoDTO(ihabilidad);
            }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<HabilidadMonstruoDTO>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<HabilidadMonstruoDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadMonstruo> habilidades = await _habilidadMonstruoRepo.ObtenerTodasLasHabilidades(); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMonstruoDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadMonstruoDTO>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<HabilidadMonstruoDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadMonstruo> habilidades = await _habilidadMonstruoRepo.ObtenerHabilidadPorTipo(tipoHabilidad);

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadMonstruoDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }
    }
}