using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemTiendaDTO
    {
        public int IdItemTienda { get; set; }
        public int PuestoDeVenta { get; set; }
        public short ItemOfertado { get; set; }


        public ItemTiendaDTO(IItemTienda item)
        {
            this.IdItemTienda = item.IdItemTienda;
            this.PuestoDeVenta = item.PuestoDeVenta;
            this.ItemOfertado = item.ItemOfertado;
        }
    }
}