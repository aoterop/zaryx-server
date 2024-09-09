using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemConsumoDTO : ItemDTO
    {
        public short CuraHp { get; set; }
        public short CuraMp { get; set; }

        public ItemConsumoDTO(IItemConsumo item) : base(item)
        {
            this.CuraHp = item.CuraHp;
            this.CuraMp = item.CuraMp;
        }
    }
}