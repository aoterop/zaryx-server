using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items.Equipo.Ofensivo
{
    public class ItemEquipoOfensivo : ItemEquipo, IItemEquipoOfensivo
    {
        public short RatioCritico { get; set; }
        public short AtaqueCritico { get; set; }
        public short AtaqueMin { get; set; }
        public short AtaqueMax { get; set; }

        public ItemEquipoOfensivo(ItemEquipoOfensivoDTO dto) : base(dto)
        {
            RatioCritico = dto.RatioCritico;
            AtaqueCritico = dto.AtaqueCritico;
            AtaqueMin = dto.AtaqueMin;
            AtaqueMax = dto.AtaqueMax;
        }

        public override byte Tipo() { return (byte)Tipos.Items.EQUIPO_OFENSIVO; }
    }
}