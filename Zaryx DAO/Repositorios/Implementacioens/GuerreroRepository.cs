using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class GuerreroRepository : IGuerreroRepository
    {
        private readonly GuerreroDao _dao;

        private readonly SemaphoreSlim _semaphore = new(1);

        public GuerreroRepository(GuerreroDao dao) { _dao = dao; }

        public async Task<bool> CrearGuerrero(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _dao.CrearGuerrero(cuentaAsociada, nombrePersonaje, peinado, aspectoFacial); }
            finally { _semaphore.Release(); }

            return creado;
        }


        public async Task<bool> EliminarGuerrero(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _dao.EliminarGuerrero(idPersonaje); }
            finally { _semaphore.Release(); }

            return eliminado;
        }


        public async Task<bool> ActualizarGuerrero(IGuerrero guerrero)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _dao.ActualizarGuerrero(guerrero); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<IGuerrero?> ObtenerGuerreroPorId(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            IGuerrero? guerrero = null;

            try { guerrero = await _dao.ObtenerGuerreroPorId(idPersonaje); }
            finally { _semaphore.Release(); }

            return guerrero;
        }

        public async Task<IGuerrero?> ObtenerGuerreroPorNombre(string nombrePersonaje)
        {
            await _semaphore.WaitAsync();

            IGuerrero? guerrero = null;

            try { guerrero = await _dao.ObtenerGuerreroPorNombre(nombrePersonaje); }
            finally { _semaphore.Release(); }

            return guerrero;
        }

        public async Task<List<IGuerrero>> ObtenerGuerrerosPorCuenta(long cuentaAsociada)
        {
            await _semaphore.WaitAsync();

            List<IGuerrero> guerreros = new();

            try { guerreros = await _dao.ObtenerGuerrerosPorCuenta(cuentaAsociada); }
            finally { _semaphore.Release(); }

            return guerreros;
        }

        public IGuerrero CrearGuerrero() { return new Guerrero(); }
    }
}