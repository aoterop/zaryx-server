using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadBasicaGuerreroRelacionDTO
    {
        public int IdHabilidadGuerrero { get; set; }
        public long RefGuerrero { get; set; }
        public short HabilidadAprendida { get; set; }

        public HabilidadBasicaGuerreroRelacionDTO(IHabilidadBasicaGuerreroRelacion habilidadRelacion)
        {
            this.IdHabilidadGuerrero = habilidadRelacion.IdHabilidadGuerrero;
            this.RefGuerrero = habilidadRelacion.RefGuerrero;
            this.HabilidadAprendida = habilidadRelacion.HabilidadAprendida;
        }
    }
}