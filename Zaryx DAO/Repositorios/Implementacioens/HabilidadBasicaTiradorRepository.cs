using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadBasicaTiradorRepository : IHabilidadBasicaTiradorRepository
    {
        private readonly HabilidadBasicaTiradorDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadBasicaTiradorRepository(HabilidadBasicaTiradorDao dao) { _dao = dao; }

        public async Task<IHabilidadBasicaTirador> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidadBasicaTirador habilidad = new HabilidadBasicaTirador();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadBasicaTirador>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaTirador> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadBasicaTirador>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadBasicaTirador> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public IHabilidadBasicaTirador CrearHabilidadBasicaTirador() { return new HabilidadBasicaTirador(); }
    }
}