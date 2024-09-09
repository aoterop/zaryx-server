namespace Zaryx_DAO.Interfaces
{
    public interface IBuffHabilidad
    {
        int IdHabilidadBuff { get; set; }
        short BuffProducido { get; set; }
        short HabilidadAsociada { get; set; }
        int ProbabilidadExito { get; set; }
    }
}