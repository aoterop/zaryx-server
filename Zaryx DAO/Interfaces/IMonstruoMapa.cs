namespace Zaryx_DAO.Interfaces
{
    public interface IMonstruoMapa
    {
        int IdMonstruoMapa { get; set; }
        short ReferenciaMapa { get; set; }
        short ReferenciaMonstruo { get; set; }
        short PosicionX { get; set; }
        short PosicionY { get; set; }
        byte OrientacionMonstruo { get; set; }
        bool PuedeMoverse { get; set; }
    }
}