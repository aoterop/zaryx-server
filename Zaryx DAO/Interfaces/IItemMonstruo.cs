namespace Zaryx_DAO.Interfaces
{
    public interface IItemMonstruo
    {
        short IdItemMonstruo { get; set; }
        short CantidadArrojada { get; set; }
        int ProbabilidadArrojar { get; set; }
        short ItemArrojable { get; set; }
        short MonstruoArrojador { get; set; }
    }
}