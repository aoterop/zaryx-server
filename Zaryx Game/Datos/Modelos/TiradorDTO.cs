using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class TiradorDTO
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

        public TiradorDTO(ITirador tirador)
        {
            this.IdPersonaje = tirador.IdPersonaje;
            this.CuentaAsociada = tirador.CuentaAsociada;
            this.NombrePersonaje = tirador.NombrePersonaje;
            this.Peinado = tirador.Peinado;
            this.AspectoFacial = tirador.AspectoFacial;
            this.EsAdmin = tirador.EsAdmin;
            this.TiempoJugado = tirador.TiempoJugado;
            this.UltimoHp = tirador.UltimoHp;
            this.UltimoMp = tirador.UltimoMp;
            this.Monedas = tirador.Monedas;
            this.NivelPersonaje = tirador.NivelPersonaje;
            this.UltimoMapa = tirador.UltimoMapa;
            this.UltimoMapaX = tirador.UltimoMapaX;
            this.UltimoMapaY = tirador.UltimoMapaY;
            this.ExperienciaPersonaje = tirador.ExperienciaPersonaje;
            this.EstaSilenciado = tirador.EstaSilenciado;
        }
    }
}