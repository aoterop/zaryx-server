namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadMaestriaGuerrero : IHabilidad
    {
        byte NivelMasterMin { get; set; }
        byte Maestria { get; set; }
    }
}