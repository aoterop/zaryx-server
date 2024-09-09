namespace Zaryx_DAO.Interfaces
{
    public interface IHabilidadBasicaGuerreroRelacion
    {
        int IdHabilidadGuerrero { get; set; }
        long RefGuerrero { get; set; }
        short HabilidadAprendida { get; set; }
    }
}