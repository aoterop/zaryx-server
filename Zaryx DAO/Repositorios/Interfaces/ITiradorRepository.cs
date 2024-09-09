using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface ITiradorRepository
    {
        Task<bool> CrearTirador(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial);
        Task<bool> EliminarTirador(long idPersonaje);
        Task<bool> ActualizarTirador(ITirador tirador);
        Task<ITirador?> ObtenerTiradorPorId(long idPersonaje);
        Task<ITirador?> ObtenerTiradorPorNombre(string nombrePersonaje);
        Task<List<ITirador>> ObtenerTiradoresPorCuenta(long cuentaAsociada);
        ITirador CrearTirador();
    }
}