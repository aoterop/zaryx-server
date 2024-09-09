using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items.Consumibles
{
    public class ItemConsumo : Item, IItemConsumo
    {
        public short CuraHp { get; set; }
        public short CuraMp { get; set; }

        public ItemConsumo(ItemConsumoDTO dto) : base(dto)
        {
            CuraHp = dto.CuraHp;
            CuraMp = dto.CuraMp;
        }

        public override byte Tipo() { return (byte)Tipos.Items.CONSUMO; }
    }
}