using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items.Miscelanea
{
    internal class ItemMiscelanea : Item, IItemMiscelanea
    {
        public byte NivelRequerido { get; set; }

        public ItemMiscelanea(ItemMiscelaneaDTO dto) : base(dto)
        {
            NivelRequerido = dto.NivelRequerido;
        }

        public override byte Tipo() { return (byte)Tipos.Items.MISCELANEA; }
    }
}