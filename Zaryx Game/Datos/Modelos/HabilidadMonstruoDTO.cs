using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadMonstruoDTO : HabilidadDTO
    {
        public short MonstruoAsignado { get; set; }

        public HabilidadMonstruoDTO(IHabilidadMonstruo habilidad) : base(habilidad)
        {
            this.MonstruoAsignado = habilidad.MonstruoAsignado;
        }
    }
}