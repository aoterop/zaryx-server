using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeHabilidadBasicaTiradorRelacion
    {
        private readonly IHabilidadBasicaTiradorRelacionRepository _habilidadBasicaTiradorRelacionRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeHabilidadBasicaTiradorRelacion(GestorDeRepos gestorDeRepos)
        {
            _habilidadBasicaTiradorRelacionRepo = gestorDeRepos.HabilidadBasicaTiradorRelacionRepo;
        }

        public async Task<HabilidadBasicaTiradorRelacionDTO> ObtenerHabilidadBasicaTiradorRelacionPorId(int idHabilidadTirador)
        {
            await _semaphore.WaitAsync();

            HabilidadBasicaTiradorRelacionDTO? habilidadRelacion = null;

            try
            {
                IHabilidadBasicaTiradorRelacion habilidad = await _habilidadBasicaTiradorRelacionRepo.ObtenerHabilidadBasicaTiradorRelacionPorId(idHabilidadTirador);
                habilidadRelacion = new HabilidadBasicaTiradorRelacionDTO(habilidad);
            }
            finally { _semaphore.Release(); }

            return habilidadRelacion;
        }

        public async Task<List<HabilidadBasicaTiradorRelacionDTO>> ObtenerHabilidadBasicaTiradorRelacionPorTirador(long refTirador)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaTiradorRelacionDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaTiradorRelacion> habilidades = await _habilidadBasicaTiradorRelacionRepo.ObtenerHabilidadBasicaTiradorRelacionPorTirador(refTirador); 

                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaTiradorRelacionDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<List<HabilidadBasicaTiradorRelacionDTO>> ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(short habilidadAdquirida)
        {
            await _semaphore.WaitAsync();

            List<HabilidadBasicaTiradorRelacionDTO> habilidadesFinales = new();

            try 
            { 
                List<IHabilidadBasicaTiradorRelacion> habilidades = await _habilidadBasicaTiradorRelacionRepo.ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(habilidadAdquirida); 
           
                foreach(var habilidad in habilidades)
                {
                    habilidadesFinales.Add(new HabilidadBasicaTiradorRelacionDTO(habilidad));
                }
            }
            finally { _semaphore.Release(); }

            return habilidadesFinales;
        }

        public async Task<bool> CrearHabilidadBasicaTiradorRelacion(long refTirador, short habilidadAdquirida)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _habilidadBasicaTiradorRelacionRepo.CrearHabilidadBasicaTiradorRelacion(refTirador, habilidadAdquirida); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaTiradorRelacion(int idHabilidadTirador)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _habilidadBasicaTiradorRelacionRepo.EliminarHabilidadBasicaTiradorRelacion(idHabilidadTirador); }
            finally { _semaphore.Release(); }

            return eliminado;
        }
    }
}