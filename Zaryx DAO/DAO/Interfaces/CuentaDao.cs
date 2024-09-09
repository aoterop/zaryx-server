using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface CuentaDao
    {
        Task<ICuenta?> ObtenerCuentaPorId(long idCuenta);
        Task<List<ICuenta>> ObtenerTodasLasCuentas();
        Task<ICuenta?> ObtenerCuentaPorMail(string email);
        Task<ICuenta?> ObtenerCuentaPorNombre(string nombreCuenta);
    }
}