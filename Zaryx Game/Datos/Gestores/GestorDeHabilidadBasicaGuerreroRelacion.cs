using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadBasicaGuerreroRelacion
    {
        private readonly IHabilidadBasicaGuerreroRelacionRepository _habilidadBasicaGuerreroRelacionRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadBasicaGuerreroRelacion(GestorDeRepos gestorDeRepos)
        {
            _habilidadBasicaGuerreroRelacionRepo = gestorDeRepos.HabilidadBasicaGuerreroRelacionRepo;
        }

        public async Task<HabilidadBasicaGuerreroRelacionDTO> ObtenerHabilidadBasicaGuerreroRelacionPorId(int idHabilidadGuerrero)
        {
            await _semaphore.WaitAsync();

            HabilidadBasicaGuerreroRelacionDTO? habilidadGuerrero = null;

            try 
            { 
                IHabilidadBasicaGuerreroRelacion habilidad = await _habilidadBasicaGuerreroRelacionRepo.ObtenerHabilidadBasicaGuerreroRelacionPorId(idHabilidadGuerrero);
                habilidadGuerrero = new HabilidadBasicaGuerreroRelacionDTO(habilidad);
            }
            finally { _semaphore.Release(); }

            return habilidadGuerrero;
        }

        public async Task<List<HabilidadBasicaGuerreroRelacionDTO>> ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(long refGuerrero)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaGuerreroRelacionDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaGuerreroRelacion> habilidades = await _habilidadBasicaGuerreroRelacionRepo.ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(refGuerrero);

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaGuerreroRelacionDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadBasicaGuerreroRelacionDTO>> ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(short habilidadAprendida)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaGuerreroRelacionDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaGuerreroRelacion> habilidades = await _habilidadBasicaGuerreroRelacionRepo.ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(habilidadAprendida);

                foreach (var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaGuerreroRelacionDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<bool> CrearHabilidadBasicaGuerreroRelacion(long refGuerrero, short habilidadAprendida)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _habilidadBasicaGuerreroRelacionRepo.CrearHabilidadBasicaGuerreroRelacion(refGuerrero, habilidadAprendida); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaGuerreroRelacion(int idHabilidadGuerrero)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _habilidadBasicaGuerreroRelacionRepo.EliminarHabilidadBasicaGuerreroRelacion(idHabilidadGuerrero); }
            finally { _semaphore.Release(); }

            return eliminado;
        }
    }
}