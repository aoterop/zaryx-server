using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadBasicaGuerreroRepository : IHabilidadBasicaGuerreroRepository
    {
        private readonly HabilidadBasicaGuerreroDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadBasicaGuerreroRepository(HabilidadBasicaGuerreroDao dao) { _dao = dao; }

        public async Task<IHabilidadBasicaGuerrero> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidadBasicaGuerrero habilidad = new HabilidadBasicaGuerrero();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadBasicaGuerrero>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaGuerrero> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadBasicaGuerrero>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaGuerrero> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public IHabilidadBasicaGuerrero CrearHabilidadBasicaGuerrero() { return new HabilidadBasicaGuerrero(); }
    }
}