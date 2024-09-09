using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadMaestriaGuerreroDTO : HabilidadDTO
    {
        public byte NivelMasterMin { get; set; }
        public byte Maestria { get; set; }

        public HabilidadMaestriaGuerreroDTO(IHabilidadMaestriaGuerrero habilidad) : base(habilidad)
        {
            this.NivelMasterMin = habilidad.NivelMasterMin;
            this.Maestria = habilidad.Maestria;
        }
    }
}