using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Interfaces
{
    public interface GuerreroDao
    {
        Task<bool> CrearGuerrero(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial);
        Task<bool> EliminarGuerrero(long idPersonaje);
        Task<bool> ActualizarGuerrero(IGuerrero guerrero);
        Task<IGuerrero?> ObtenerGuerreroPorId(long idPersonaje);
        Task<IGuerrero?> ObtenerGuerreroPorNombre(string nombrePersonaje);
        Task<List<IGuerrero>> ObtenerGuerrerosPorCuenta(long cuentaAsociada);
    }
}