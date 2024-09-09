using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemDTO
    {
        public short IdItem { get; set; }
        public string NombreItem { get; set; }
        public string? DetallesItem { get; set; }
        public long Precio { get; set; }
        public bool EsArrojable { get; set; }

        public ItemDTO(IItem item)
        {
            this.IdItem = item.IdItem;
            this.NombreItem = item.NombreItem;
            this.DetallesItem= item.DetallesItem;
            this.Precio= item.Precio;
            this.EsArrojable= item.EsArrojable;
        }
    }
}