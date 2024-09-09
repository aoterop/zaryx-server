using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface ICuentaRepository
    {
        Task<ICuenta?> ObtenerCuentaPorId(long idCuenta);
        Task<List<ICuenta>> ObtenerTodasLasCuentas();
        Task<ICuenta?> ObtenerCuentaPorMail(string email);
        Task<ICuenta?> ObtenerCuentaPorNombre(string nombreCuenta);
        ICuenta CrearCuenta();
    }
}