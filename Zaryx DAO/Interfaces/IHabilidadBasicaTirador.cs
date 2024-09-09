namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadBasicaTirador : IHabilidad
    {
        bool RequiereObjetivo { get; set; }
        byte NivelRequerido { get; set; }
    }
}