using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items.Equipo.Defensivo
{
    public class ItemEquipoDefensivo : ItemEquipo, IItemEquipoDefensivo
    {
        public byte TipoEquipoDefensivo { get; set; }
        public short DefensaItem { get; set; }
        public byte VelocidadExtra { get; set; }

        public ItemEquipoDefensivo(ItemEquipoDefensivoDTO dto) : base(dto)
        {
            TipoEquipoDefensivo = dto.TipoEquipoDefensivo;
            DefensaItem = dto.DefensaItem;
            VelocidadExtra = dto.VelocidadExtra;
        }

        public override byte Tipo() { return (byte)Tipos.Items.EQUIPO_DEFENSIVO; }
    }
}