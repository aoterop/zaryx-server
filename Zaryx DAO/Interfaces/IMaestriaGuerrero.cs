namespace Zaryx_DAO.Interfaces
{
    public interface IMaestriaGuerrero : IItem
    {
        byte NivelMinimo { get; set; }
        byte NumeroMaestria { get; set; }
    }
}