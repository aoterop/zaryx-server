namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadMaestriaTirador : IHabilidad
    {
        byte NivelMasterMin { get; set; }
        byte Maestria { get; set; }
    }
}