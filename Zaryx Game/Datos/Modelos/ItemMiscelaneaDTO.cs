using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemMiscelaneaDTO : ItemDTO
    {
        public byte NivelRequerido { get; set; }


        public ItemMiscelaneaDTO(IItemMiscelanea item) : base(item)
        {
            this.NivelRequerido = item.NivelRequerido;
        }
    }
}