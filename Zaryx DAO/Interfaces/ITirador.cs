namespace Zaryx_DAO.Interfaces
{
    public interface ITirador
    {
        long IdPersonaje { get; set; }
        long CuentaAsociada { get; set; }
        string NombrePersonaje { get; set; }
        byte Peinado { get; set; }
        byte AspectoFacial { get; set; }
        bool EsAdmin { get; set; }
        int TiempoJugado { get; set; }
        int UltimoHp { get; set; }
        int UltimoMp { get; set; }
        long Monedas { get; set; }
        byte NivelPersonaje { get; set; }
        short UltimoMapa { get; set; }
        short UltimoMapaX { get; set; }
        short UltimoMapaY { get; set; }
        long ExperienciaPersonaje { get; set; }
        bool EstaSilenciado { get; set; }
    }
}