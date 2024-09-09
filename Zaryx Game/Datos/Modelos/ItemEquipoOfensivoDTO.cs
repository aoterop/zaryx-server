using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemEquipoOfensivoDTO : ItemEquipoDTO
    {
        public short RatioCritico { get; set; }
        public short AtaqueCritico { get; set; }
        public short AtaqueMin { get; set; }
        public short AtaqueMax { get; set; }

        public ItemEquipoOfensivoDTO(IItemEquipoOfensivo item) : base(item)
        {
            this.RatioCritico = item.RatioCritico;
            this.AtaqueCritico = item.AtaqueCritico;
            this.AtaqueMin = item.AtaqueMin;
            this.AtaqueMax = item.AtaqueMax;
        }
    }
}