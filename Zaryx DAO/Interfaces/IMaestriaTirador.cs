namespace Zaryx_DAO.Interfaces
{
    public interface IMaestriaTirador : IItem
    {
        byte NivelMinimo { get; set; }
        byte NumeroMaestria { get; set; }
    }
}