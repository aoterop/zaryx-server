using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadBasicaTiradorRelacionDTO
    {
        public int IdHabilidadTirador { get; set; }
        public long RefTirador { get; set; }
        public short HabilidadAdquirida { get; set; }

        public HabilidadBasicaTiradorRelacionDTO(IHabilidadBasicaTiradorRelacion habilidadRelacion)
        {
            this.IdHabilidadTirador = habilidadRelacion.IdHabilidadTirador;
            this.RefTirador = habilidadRelacion.RefTirador;
            this.HabilidadAdquirida = habilidadRelacion.HabilidadAdquirida;
        }
    }
}