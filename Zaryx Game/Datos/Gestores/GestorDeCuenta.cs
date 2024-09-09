using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeCuenta
    {
        private readonly ICuentaRepository _cuentaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeCuenta(GestorDeRepos gestorDeRepos)
        {
            _cuentaRepo = gestorDeRepos.CuentaRepo;
        }

        public async Task<CuentaDTO?> ObtenerCuentaPorId(long idCuenta)
        {
            await _semaphore.WaitAsync();

            CuentaDTO? cuenta = null;

            try
            {
                ICuenta? iCuenta = await _cuentaRepo.ObtenerCuentaPorId(idCuenta);
                if (iCuenta != null) { cuenta = new CuentaDTO(iCuenta); }
            }
            finally { _semaphore.Release(); }

            return cuenta;
        }


        public async Task<List<CuentaDTO>> ObtenerCuentas()
        {
            await _semaphore.WaitAsync();

            List<CuentaDTO>? cuentasFinales = new();

            try
            {
                List<ICuenta> iCuentas = await _cuentaRepo.ObtenerTodasLasCuentas();
                
                foreach(var cuenta in iCuentas)
                {
                    cuentasFinales.Add(new CuentaDTO(cuenta));
                }
            }
            finally { _semaphore.Release(); }

            return cuentasFinales;
        }

        public async Task<CuentaDTO?> ObtenerCuentaPorMail(string email)
        {
            await _semaphore.WaitAsync();

            CuentaDTO? cuenta = null;

            try
            {
                ICuenta? iCuenta = await _cuentaRepo.ObtenerCuentaPorMail(email);
                if (iCuenta != null) { cuenta = new CuentaDTO(iCuenta); }
            }
            finally { _semaphore.Release(); }

            return cuenta;
        }


        public async Task<CuentaDTO?> ObtenerCuentaPorNombre(string nombreCuenta)
        {
            await _semaphore.WaitAsync();

            CuentaDTO? cuenta = null;

            try
            {
                ICuenta? iCuenta = await _cuentaRepo.ObtenerCuentaPorNombre(nombreCuenta);
                if (iCuenta != null) { cuenta = new CuentaDTO(iCuenta); }
            }
            finally { _semaphore.Release(); }

            return cuenta;
        }
    }
}