namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidad
    {
        short IdHabilidad { get; set; }
        string NombreHabilidad { get; set; }
        string? DetallesHabilidad { get; set; }
        byte RangoAlcance { get; set; }
        byte Area { get; set; }
        short TiempoCarga { get; set; }
        short DuracionHabilidad { get; set; }
        short ConsumoMp { get; set; }
        byte TipoHabilidad { get; set; }
        short DamageBase { get; set; }
    }
}