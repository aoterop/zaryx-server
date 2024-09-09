namespace Zaryx_DAO.Interfaces
{
    public interface IItemEquipo : IItem
    {
        byte NivelRequerido { get; set; }
        byte ClasePermitida { get; set; }
    }
}
