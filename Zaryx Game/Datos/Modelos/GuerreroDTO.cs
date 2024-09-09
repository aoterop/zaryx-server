using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class GuerreroDTO
    {
        public long IdPersonaje { get; set; }
        public long CuentaAsociada { get; set; }
        public string? NombrePersonaje { get; set; }
        public byte Peinado { get; set; }
        public byte AspectoFacial { get; set; }
        public bool EsAdmin { get; set; }
        public int TiempoJugado { get; set; }
        public int UltimoHp { get; set; }
        public int UltimoMp { get; set; }
        public long Monedas { get; set; }
        public byte NivelPersonaje { get; set; }
        public short UltimoMapa { get; set; }
        public short UltimoMapaX { get; set; }
        public short UltimoMapaY { get; set; }
        public long ExperienciaPersonaje { get; set; }
        public bool EstaSilenciado { get; set; }

        public GuerreroDTO(IGuerrero guerrero)
        {
            this.IdPersonaje = guerrero.IdPersonaje;
            this.CuentaAsociada = guerrero.CuentaAsociada;
            this.NombrePersonaje = guerrero.NombrePersonaje;
            this.Peinado = guerrero.Peinado;
            this.AspectoFacial = guerrero.AspectoFacial;
            this.EsAdmin = guerrero.EsAdmin;
            this.TiempoJugado = guerrero.TiempoJugado;
            this.UltimoHp = guerrero.UltimoHp;
            this.UltimoMp = guerrero.UltimoMp;
            this.Monedas = guerrero.Monedas;
            this.NivelPersonaje = guerrero.NivelPersonaje;
            this.UltimoMapa = guerrero.UltimoMapa;
            this.UltimoMapaX = guerrero.UltimoMapaX;
            this.UltimoMapaY = guerrero.UltimoMapaY;
            this.ExperienciaPersonaje = guerrero.ExperienciaPersonaje;
            this.EstaSilenciado = guerrero.EstaSilenciado;
        }
    }
}