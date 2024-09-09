using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemBuffDTO
    {
        public int IdItemBuff { get; set; }
        public short ItemGenerador { get; set; }
        public short BuffGenerador { get; set; }
        public bool EsGrupal { get; set; }

        public ItemBuffDTO(IItemBuff item)
        {
            this.IdItemBuff = item.IdItemBuff;
            this.ItemGenerador = item.ItemGenerador;
            this.BuffGenerador = item.BuffGenerador;
            this.EsGrupal = item.EsGrupal;
        }
    }
}