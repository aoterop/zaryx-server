namespace Zaryx_DAO.Interfaces
{
    public interface IItemEquipoDefensivo : IItemEquipo
    {
        byte TipoEquipoDefensivo { get; set; }
        short DefensaItem { get; set; }
        byte VelocidadExtra { get; set; }
    }
}