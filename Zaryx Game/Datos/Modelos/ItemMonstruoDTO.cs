using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class ItemMonstruoDTO
    {
        public short IdItemMonstruo { get; set; }
        public short CantidadArrojada { get; set; }
        public int ProbabilidadArrojar { get; set; }
        public short ItemArrojable { get; set; }
        public short MonstruoArrojador { get; set; }

        public ItemMonstruoDTO(IItemMonstruo item)
        {
            this.IdItemMonstruo = item.IdItemMonstruo;
            this.CantidadArrojada = item.CantidadArrojada;
            this.ProbabilidadArrojar = item.ProbabilidadArrojar;
            this.ItemArrojable = item.ItemArrojable;
            this.MonstruoArrojador = item.MonstruoArrojador;
        }
    }
}