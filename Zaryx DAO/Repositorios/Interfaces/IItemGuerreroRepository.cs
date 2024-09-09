using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IItemGuerreroRepository
    {
        Task<long> CrearItemGuerrero(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario);
        Task<bool> EliminarItemGuerrero(long idItemGuerrero);
        Task<bool> ActualizarItemGuerrero(IItemGuerrero itemGuerrero);
        Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeTodosLosGuerreros();
        Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeUnGuerrero(long propietario);
        IItemGuerrero CrearItemGuerrero();
    }
}