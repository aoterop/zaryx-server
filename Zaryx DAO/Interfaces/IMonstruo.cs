namespace Zaryx_DAO.Interfaces
{
    public interface IMonstruo
    {
        short IdMonstruo { get; set; }
        string NombreMonstruo { get; set; }
        string? DetallesMonstruo { get; set; }
        int TiempoReaparicion { get; set; }
        byte VelocidadMonstruo { get; set; }
        int AumentoExperiencia { get; set; }
        byte NivelMonstruo { get; set; }
        int MaxHpMonstruo { get; set; }
        int MaxMpMonstruo { get; set; }
        short AtaqueMinMonstruo { get; set; }
        short AtaqueMaxMonstruo { get; set; }
        short DefensaMonstruo { get; set; }
        bool EsAgresivo { get; set; }
    }
}