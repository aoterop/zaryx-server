using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador
{
    public class ItemTirador : IItemTirador
    {
        public long IdItemPersonaje { get; set; }
        public long IdItemTirador { get; set; }
        public long Propietario { get; set; }
        public short ReferenciaItem { get; set; }
        public short Cantidad { get; set; }
        public byte NivelItem { get; set; }
        public long ExperienciaItem { get; set; }
        public byte RanuraInventario { get; set; }

        public ItemTirador(ItemTiradorDTO dto)
        {
            IdItemPersonaje = dto.IdItemTirador;
            IdItemTirador = dto.IdItemTirador;
            Propietario = dto.Propietario;
            ReferenciaItem = dto.ReferenciaItem;
            Cantidad = dto.Cantidad;
            NivelItem = dto.NivelItem;
            ExperienciaItem = dto.ExperienciaItem;
            RanuraInventario = dto.RanuraInventario;
        }

        public ItemTirador() { }

        public ItemTirador Clone()
        {
            return new ItemTirador
            {
                RanuraInventario = this.RanuraInventario,
                IdItemTirador = this.IdItemTirador,
                IdItemPersonaje = this.IdItemTirador,
                Propietario = this.Propietario,
                Cantidad = this.Cantidad,
                NivelItem = this.NivelItem,
                ExperienciaItem = this.ExperienciaItem,
                ReferenciaItem = this.ReferenciaItem
            };
        }
    }
}