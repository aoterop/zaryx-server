using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class MonstruoDTO
    {
        public short IdMonstruo { get; set; }
        public string? NombreMonstruo { get; set; }
        public string? DetallesMonstruo { get; set; }
        public int TiempoReaparicion { get; set; }
        public byte VelocidadMonstruo { get; set; }
        public int AumentoExperiencia { get; set; }
        public byte NivelMonstruo { get; set; }
        public int MaxHpMonstruo { get; set; }
        public int MaxMpMonstruo { get; set; }
        public short AtaqueMinMonstruo { get; set; }
        public short AtaqueMaxMonstruo { get; set; }
        public short DefensaMonstruo { get; set; }
        public bool EsAgresivo { get; set; }

        public MonstruoDTO(IMonstruo monstruo)
        {
            this.IdMonstruo = monstruo.IdMonstruo;
            this.NombreMonstruo = monstruo.NombreMonstruo;
            this.DetallesMonstruo = monstruo.DetallesMonstruo;
            this.TiempoReaparicion = monstruo.TiempoReaparicion;
            this.VelocidadMonstruo = monstruo.VelocidadMonstruo;
            this.AumentoExperiencia = monstruo.AumentoExperiencia;
            this.NivelMonstruo = monstruo.NivelMonstruo;
            this.MaxHpMonstruo = monstruo.MaxHpMonstruo;
            this.MaxMpMonstruo = monstruo.MaxMpMonstruo;
            this.AtaqueMinMonstruo = monstruo.AtaqueMinMonstruo;
            this.AtaqueMaxMonstruo = monstruo.AtaqueMaxMonstruo;
            this.DefensaMonstruo = monstruo.DefensaMonstruo;
            this.EsAgresivo = monstruo.EsAgresivo;
        }
    }
}