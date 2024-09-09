namespace Zaryx_DAO.Interfaces
{
    public interface IItemGuerrero
    {
        long IdItemGuerrero { get; set; }
        long Propietario { get; set; }
        short ReferenciaItem { get; set; }
        short Cantidad { get; set; }
        byte NivelItem { get; set; }
        long ExperienciaItem { get; set; }
        byte RanuraInventario { get; set; }
    }
}
