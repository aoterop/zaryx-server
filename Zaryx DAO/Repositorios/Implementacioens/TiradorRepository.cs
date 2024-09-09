using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class TiradorRepository : ITiradorRepository
    {
        private readonly TiradorDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public TiradorRepository(TiradorDao dao) { _dao = dao; }

        public async Task<bool> CrearTirador(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _dao.CrearTirador(cuentaAsociada, nombrePersonaje, peinado, aspectoFacial); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarTirador(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarTirador(idPersonaje); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public async Task<bool> ActualizarTirador(ITirador tirador)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _dao.ActualizarTirador(tirador); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<ITirador?> ObtenerTiradorPorId(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            ITirador? tirador = null;

            try { tirador = await _dao.ObtenerTiradorPorId(idPersonaje); }
            finally { _semaphore.Release(); }

            return tirador;
        }

        public async Task<ITirador?> ObtenerTiradorPorNombre(string nombrePersonaje)
        {
            await _semaphore.WaitAsync();

            ITirador? tirador = null;

            try { tirador = await _dao.ObtenerTiradorPorNombre(nombrePersonaje); }
            finally { _semaphore.Release(); }

            return tirador;
        }

        public async Task<List<ITirador>> ObtenerTiradoresPorCuenta(long cuentaAsociada)
        {
            await _semaphore.WaitAsync();

            List<ITirador> tiradores = new();

            try { tiradores = await _dao.ObtenerTiradoresPorCuenta(cuentaAsociada); }
            finally { _semaphore.Release(); }

            return tiradores;
        }

        public ITirador CrearTirador() { return new Tirador(); }
    }
}