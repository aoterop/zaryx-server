using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadMaestriaGuerreroRepository : IHabilidadMaestriaGuerreroRepository
    {
        private readonly HabilidadMaestriaGuerreroDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadMaestriaGuerreroRepository(HabilidadMaestriaGuerreroDao dao) { _dao = dao; }

        public async Task<IHabilidadMaestriaGuerrero> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidadMaestriaGuerrero habilidad = new HabilidadMaestriaGuerrero();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadMaestriaGuerrero>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMaestriaGuerrero> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadMaestriaGuerrero>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMaestriaGuerrero> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public IHabilidadMaestriaGuerrero CrearHabilidadMaestriaGuerrero() { return new HabilidadMaestriaGuerrero(); }
    }
}