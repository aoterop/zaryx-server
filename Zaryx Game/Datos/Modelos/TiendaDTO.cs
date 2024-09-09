using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class TiendaDTO
    {
        public int IdTienda { get; set; }
        public string? NombreTienda { get; set; }
        public byte RatioCompra { get; set; }
        public string? NombreNpc { get; set; }
        public byte OrientacionNpc { get; set; }
        public short TiendaX { get; set; }
        public short TiendaY { get; set; }
        public short MapaTienda { get; set; }

        public TiendaDTO(ITienda tienda)
        {
            this.IdTienda = tienda.IdTienda;
            this.NombreTienda = tienda.NombreTienda;
            this.RatioCompra = tienda.RatioCompra;
            this.NombreNpc = tienda.NombreNpc;
            this.OrientacionNpc = tienda.OrientacionNpc;
            this.TiendaX = tienda.TiendaX;
            this.TiendaY = tienda.TiendaY;
            this.MapaTienda = tienda.MapaTienda;
        }
    }
}