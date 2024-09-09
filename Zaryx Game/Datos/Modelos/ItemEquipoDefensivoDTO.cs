using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemEquipoDefensivoDTO : ItemEquipoDTO
    {
        public byte TipoEquipoDefensivo { get; set; }
        public short DefensaItem { get; set; }
        public byte VelocidadExtra { get; set; }

        public ItemEquipoDefensivoDTO(IItemEquipoDefensivo item) : base(item)
        {
            this.TipoEquipoDefensivo = item.TipoEquipoDefensivo;
            this.DefensaItem = item.DefensaItem;
            this.VelocidadExtra = item.VelocidadExtra;
        }
    }
}