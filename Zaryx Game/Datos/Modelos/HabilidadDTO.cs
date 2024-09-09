using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class HabilidadDTO
    {
        public short IdHabilidad { get; set; }
        public string? NombreHabilidad { get; set; }
        public string? DetallesHabilidad { get; set; }
        public byte RangoAlcance { get; set; }
        public byte Area { get; set; }
        public short TiempoCarga { get; set; }
        public short DuracionHabilidad { get; set; }
        public short ConsumoMp { get; set; }
        public byte TipoHabilidad { get; set; }
        public short DamageBase { get; set; }

        public HabilidadDTO(IHabilidad habilidad)
        {
            this.IdHabilidad = habilidad.IdHabilidad;
            this.NombreHabilidad = habilidad.NombreHabilidad;
            this.DetallesHabilidad = habilidad.NombreHabilidad;
            this.RangoAlcance = habilidad.RangoAlcance;
            this.Area = habilidad.Area;
            this.TiempoCarga = habilidad.TiempoCarga;
            this.DuracionHabilidad = habilidad.DuracionHabilidad;
            this.ConsumoMp = habilidad.ConsumoMp;
            this.TipoHabilidad = habilidad.TipoHabilidad;
            this.DamageBase= habilidad.DamageBase;
        }
    }
}