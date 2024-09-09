using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadRepository : IHabilidadRepository<IHabilidad>
    {
        private readonly HabilidadDao<IHabilidad> _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadRepository(HabilidadDao<IHabilidad> dao) { _dao = dao; }

        public async Task<IHabilidad> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidad habilidad = new Habilidad();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidad>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidad> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidad>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidad> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }
    }
}