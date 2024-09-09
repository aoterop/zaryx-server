using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadBasicaTiradorRelacionRepository : IHabilidadBasicaTiradorRelacionRepository
    {
        private readonly HabilidadBasicaTiradorRelacionDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadBasicaTiradorRelacionRepository(HabilidadBasicaTiradorRelacionDao dao) { _dao = dao; }


        public async Task<IHabilidadBasicaTiradorRelacion> ObtenerHabilidadBasicaTiradorRelacionPorId(int idHabilidadTirador)
        {
            await _semaphore.WaitAsync();

            IHabilidadBasicaTiradorRelacion habilidad = new HabilidadBasicaTiradorRelacion();

            try { habilidad = await _dao.ObtenerHabilidadBasicaTiradorRelacionPorId(idHabilidadTirador); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorTirador(long refTirador)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaTiradorRelacion> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadBasicaTiradorRelacionPorTirador(refTirador); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(short habilidadAdquirida)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaTiradorRelacion> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(habilidadAdquirida); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<bool> CrearHabilidadBasicaTiradorRelacion(long refTirador, short habilidadAdquirida)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _dao.CrearHabilidadBasicaTiradorRelacion(refTirador, habilidadAdquirida); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaTiradorRelacion(int idHabilidadTirador)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarHabilidadBasicaTiradorRelacion(idHabilidadTirador); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public IHabilidadBasicaTiradorRelacion CrearHabilidadBasicaTiradorRelacion() { return new HabilidadBasicaTiradorRelacion(); }
    }
}