using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadMonstruoRepository : IHabilidadMonstruoRepository
    {
        private readonly HabilidadMonstruoDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadMonstruoRepository(HabilidadMonstruoDao dao) { _dao = dao; }

        public async Task<IHabilidadMonstruo> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidadMonstruo habilidad = new HabilidadMonstruo();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadMonstruo>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMonstruo> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadMonstruo>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMonstruo> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public IHabilidadMonstruo CrearHabilidadMonstruo() { return new HabilidadMonstruo(); }
    }
}