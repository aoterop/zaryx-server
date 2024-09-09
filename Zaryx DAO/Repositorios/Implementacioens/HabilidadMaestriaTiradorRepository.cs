using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class HabilidadMaestriaTiradorRepository : IHabilidadMaestriaTiradorRepository
    {
        private readonly HabilidadMaestriaTiradorDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public HabilidadMaestriaTiradorRepository(HabilidadMaestriaTiradorDao dao) { _dao = dao; }

        public async Task<IHabilidadMaestriaTirador> ObtenerHabilidadPorId(short idHabilidad)
        {
            await _semaphore.WaitAsync();

            IHabilidadMaestriaTirador habilidad = new HabilidadMaestriaTirador();

            try { habilidad = await _dao.ObtenerHabilidadPorId(idHabilidad); }
            finally { _semaphore.Release(); }

            return habilidad;
        }

        public async Task<List<IHabilidadMaestriaTirador>> ObtenerTodasLasHabilidades()
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMaestriaTirador> habilidades = new();

            try { habilidades = await _dao.ObtenerTodasLasHabilidades(); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public async Task<List<IHabilidadMaestriaTirador>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            await _semaphore.WaitAsync();

            List<IHabilidadMaestriaTirador> habilidades = new();

            try { habilidades = await _dao.ObtenerHabilidadPorTipo(tipoHabilidad); }
            finally { _semaphore.Release(); }

            return habilidades;
        }

        public IHabilidadMaestriaTirador CrearHabilidadMaestriaTirador() { return new HabilidadMaestriaTirador(); }
    }
}