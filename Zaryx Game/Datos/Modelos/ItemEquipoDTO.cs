using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemEquipoDTO : ItemDTO
    {
        public byte NivelRequerido { get; set; }
        public byte ClasePermitida { get; set; }

        public ItemEquipoDTO(IItemEquipo item) : base(item)
        {
            this.NivelRequerido = item.NivelRequerido;
            this.ClasePermitida = item.ClasePermitida;
        }
    }
}