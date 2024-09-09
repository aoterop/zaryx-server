using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Juego.Modelos.Items.Equipo
{
    public class ItemEquipo : Item, IItemEquipo
    {
        public byte NivelRequerido { get; set; }
        public byte ClasePermitida { get; set; }

        public ItemEquipo(ItemEquipoDTO dto) : base(dto)
        {
            NivelRequerido = dto.NivelRequerido;
            ClasePermitida = dto.ClasePermitida;
        }
    }
}