namespace Zaryx_DAO.Interfaces
{
    public interface IItemTirador
    {
        long IdItemTirador { get; set; }
        long Propietario { get; set; }
        short ReferenciaItem { get; set; }
        short Cantidad { get; set; }
        byte NivelItem { get; set; }
        long ExperienciaItem { get; set; }
        byte RanuraInventario { get; set; }
    }
}