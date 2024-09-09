namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadBasicaGuerrero : IHabilidad
    {
        bool RequiereObjetivo { get; set; }
        byte NivelRequerido { get; set; }
    }
}