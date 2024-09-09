using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadBasicaGuerreroDTO : HabilidadDTO
    {
        public bool RequiereObjetivo { get; set; }
        public byte NivelRequerido { get; set; }

        public HabilidadBasicaGuerreroDTO(IHabilidadBasicaGuerrero habilidad) : base(habilidad)
        {
            this.RequiereObjetivo = habilidad.RequiereObjetivo;
            this.NivelRequerido = habilidad.NivelRequerido;
        }
    }
}