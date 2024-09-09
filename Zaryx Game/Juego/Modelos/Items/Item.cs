using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items
{
    public class Item : IItem
    {
        public short IdItem { get; set; }
        public string NombreItem { get; set; }
        public string? DetallesItem { get; set; }
        public long Precio { get; set; }
        public bool EsArrojable { get; set; }

        public virtual byte Tipo() { return (byte)Tipos.Items.NO_ESPECIFICADO; }

        public Item(ItemDTO dto)
        {
            IdItem = dto.IdItem;
            NombreItem = dto.NombreItem;
            DetallesItem = dto.DetallesItem;
            Precio = dto.Precio;
            EsArrojable = dto.EsArrojable;
        }
    }
}