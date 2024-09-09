namespace Zaryx_DAO.Interfaces
{
    public interface IItemEquipoOfensivo : IItemEquipo
    {
        short RatioCritico { get; set; }

        short AtaqueCritico { get; set; }
        short AtaqueMin { get; set; }
        short AtaqueMax { get; set; }
    }
}