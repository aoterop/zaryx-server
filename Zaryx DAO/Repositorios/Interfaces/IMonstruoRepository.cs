using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IMonstruoRepository
    {
        Task<IMonstruo> ObtenerMonstruoPorId(short idMonstruo);
        Task<List<IMonstruo>> ObtenerTodosLosMonstruos();
        IMonstruo CrearMonstruo();
    }
}