namespace Zaryx_DAO.Interfaces
{
    public interface IItem
    {
        short IdItem { get; set; }
        string NombreItem { get; set; }
        string? DetallesItem { get; set; }
        long Precio { get; set; }
        bool EsArrojable { get; set; }
    }
}