using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Juego.Modelos.Items.Guerrero
{
    public class ItemGuerrero : IItemGuerrero
    {
        public long IdItemPersonaje { get; set; }
        public long IdItemGuerrero { get; set; }
        public long Propietario { get; set; }
        public short ReferenciaItem { get; set; }
        public short Cantidad { get; set; }
        public byte NivelItem { get; set; }
        public long ExperienciaItem { get; set; }
        public byte RanuraInventario { get; set; }

        public ItemGuerrero(ItemGuerreroDTO dto)
        {
            IdItemPersonaje = dto.IdItemGuerrero;
            IdItemGuerrero = dto.IdItemGuerrero;
            Propietario = dto.Propietario;
            ReferenciaItem = dto.ReferenciaItem;
            Cantidad = dto.Cantidad;
            NivelItem = dto.NivelItem;
            ExperienciaItem = dto.ExperienciaItem;
            RanuraInventario = dto.RanuraInventario;
        }

        public ItemGuerrero() { }

        public ItemGuerrero Clone()
        {
            return new ItemGuerrero
            {
                RanuraInventario = this.RanuraInventario,
                IdItemGuerrero = this.IdItemGuerrero,
                IdItemPersonaje = this.IdItemGuerrero,
                Propietario = this.Propietario,
                NivelItem = this.NivelItem,
                Cantidad = this.Cantidad,
                ExperienciaItem = this.ExperienciaItem,
                ReferenciaItem = this.ReferenciaItem
            };
        }
    }
}