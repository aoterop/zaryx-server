namespace Zaryx_DAO.Interfaces
{
    public interface ITienda
    {
        int IdTienda { get; set; }
        string? NombreTienda { get; set; }
        byte RatioCompra { get; set; }
        string? NombreNpc { get; set; }
        byte OrientacionNpc { get; set; }
        short TiendaX { get; set; }
        short TiendaY { get; set; }
        short MapaTienda { get; set; }
    }
}