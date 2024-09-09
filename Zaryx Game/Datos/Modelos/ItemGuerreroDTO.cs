using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemGuerreroDTO
    {
        public long IdItemGuerrero { get; set; }
        public long Propietario { get; set; }
        public short ReferenciaItem { get; set; }
        public short Cantidad { get; set; }
        public byte NivelItem { get; set; }
        public long ExperienciaItem { get; set; }
        public byte RanuraInventario { get; set; }

        public ItemGuerreroDTO(IItemGuerrero item)
        {
            this.IdItemGuerrero = item.IdItemGuerrero;
            this.Propietario = item.Propietario;
            this.ReferenciaItem = item.ReferenciaItem;
            this.Cantidad = item.Cantidad;
            this.NivelItem = item.NivelItem;
            this.ExperienciaItem = item.ExperienciaItem;
            this.RanuraInventario = item.RanuraInventario;
        }
    }
}