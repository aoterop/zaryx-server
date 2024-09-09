using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadBasicaGuerreroRelacionRepository : IHabilidadBasicaGuerreroRelacionRepository
    {
        private readonly HabilidadBasicaGuerreroRelacionDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadBasicaGuerreroRelacionRepository(HabilidadBasicaGuerreroRelacionDao dao) { _dao = dao; }

        public async Task<IHabilidadBasicaGuerreroRelacion> ObtenerHabilidadBasicaGuerreroRelacionPorId(int idHabilidadGuerrero)
        {
            await _semaphore.WaitAsync();

            IHabilidadBasicaGuerreroRelacion habilidadGuerrero = new HabilidadBasicaGuerreroRelacion();

            try { habilidadGuerrero = await _dao.ObtenerHabilidadBasicaGuerreroRelacionPorId(idHabilidadGuerrero); }
            finally { _semaphore.Release(); }

            return habilidadGuerrero;
        }

        public async Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(long refGuerrero)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaGuerreroRelacion> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(refGuerrero); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(short habilidadAprendida)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaGuerreroRelacion> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(habilidadAprendida); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<bool> CrearHabilidadBasicaGuerreroRelacion(long refGuerrero, short habilidadAprendida)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _dao.CrearHabilidadBasicaGuerreroRelacion(refGuerrero, habilidadAprendida); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaGuerreroRelacion(int idHabilidadGuerrero)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarHabilidadBasicaGuerreroRelacion(idHabilidadGuerrero); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public IHabilidadBasicaGuerreroRelacion CrearHabilidadBasicaGuerreroRelacion() { return new HabilidadBasicaGuerreroRelacion(); }
    }
}