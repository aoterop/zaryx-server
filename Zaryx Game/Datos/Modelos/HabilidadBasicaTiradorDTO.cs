using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadBasicaTiradorDTO : HabilidadDTO
    {
        public bool RequiereObjetivo { get; set; }
        public byte NivelRequerido { get; set; }

        public HabilidadBasicaTiradorDTO(IHabilidadBasicaTirador habilidad) : base(habilidad)
        {
            this.RequiereObjetivo = habilidad.RequiereObjetivo;
            this.NivelRequerido = habilidad.NivelRequerido;
        }
    }
}