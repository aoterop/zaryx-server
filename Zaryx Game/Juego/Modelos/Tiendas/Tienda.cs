using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Estructuras;

namespace Zaryx_Game.Juego.Modelos.Tiendas
{
    public class Tienda : ITienda
    {
        public int IdTienda { get; set; }
        public string? NombreTienda { get; set; }
        public byte RatioCompra { get; set; }
        public string? NombreNpc { get; set; }
        public byte OrientacionNpc { get; set; }
        public short TiendaX { get; set; }
        public short TiendaY { get; set; }
        public short MapaTienda { get; set; }

        public List<ItemTienda> ItemsTienda { get; set; }

        public Tienda(TiendaDTO dto)
        {
            IdTienda = dto.IdTienda;
            NombreTienda = dto.NombreTienda;
            RatioCompra = dto.RatioCompra;
            NombreNpc = dto.NombreNpc;
            OrientacionNpc = dto.OrientacionNpc;
            TiendaX = dto.TiendaX;
            TiendaY = dto.TiendaY;
            MapaTienda = dto.MapaTienda;

            ItemsTienda = new List<ItemTienda>();
        }
    }
}