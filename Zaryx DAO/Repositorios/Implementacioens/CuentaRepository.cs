using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class CuentaRepository : ICuentaRepository
    {
        private readonly CuentaDao _dao;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public CuentaRepository(CuentaDao dao) { _dao = dao; }

        public async Task<ICuenta?> ObtenerCuentaPorId(long idCuenta)
        {
            await _semaphore.WaitAsync();

            ICuenta? cuenta = null;

            try { cuenta = await _dao.ObtenerCuentaPorId(idCuenta); }
            finally { _semaphore.Release(); }

            return cuenta;
        }

        public async Task<List<ICuenta>> ObtenerTodasLasCuentas()
        {
            await _semaphore.WaitAsync();

            List<ICuenta> cuentas = new();

            try { cuentas = await _dao.ObtenerTodasLasCuentas(); }
            finally { _semaphore.Release(); }

            return cuentas;
        }

        public async Task<ICuenta?> ObtenerCuentaPorMail(string email)
        {
            await _semaphore.WaitAsync();

            ICuenta? cuenta = null;

            try { cuenta = await _dao.ObtenerCuentaPorMail(email); }
            finally { _semaphore.Release(); }

            return cuenta;
        }

        public async Task<ICuenta?> ObtenerCuentaPorNombre(string nombreCuenta)
        {
            await _semaphore.WaitAsync();

            ICuenta? cuenta = null;

            try { cuenta = await _dao.ObtenerCuentaPorNombre(nombreCuenta); }
            finally { _semaphore.Release(); }

            return cuenta;
        }
        public ICuenta CrearCuenta() { return new Cuenta(); }
    }
}