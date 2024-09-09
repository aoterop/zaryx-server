using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Juego.Modelos.Tiendas
{
    public class ItemTienda : IItemTienda
    {
        public int IdItemTienda { get; set; }
        public int PuestoDeVenta { get; set; }
        public short ItemOfertado { get; set; }

        public ItemTienda(ItemTiendaDTO dto)
        {
            IdItemTienda = dto.IdItemTienda;
            PuestoDeVenta = dto.PuestoDeVenta;
            ItemOfertado = dto.ItemOfertado;
        }
    }
}