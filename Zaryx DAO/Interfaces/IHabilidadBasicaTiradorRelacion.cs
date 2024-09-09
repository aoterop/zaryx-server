namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadBasicaTiradorRelacion
    {
        int IdHabilidadTirador { get; set; }
        long RefTirador { get; set; }
        short HabilidadAdquirida { get; set; }
    }
}