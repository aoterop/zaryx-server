namespace Zaryx_DAO.Interfaces
{
    public interface IPortal
    {
        int IdPortal { get; set; }
        short DestinoX { get; set; }
        short DestinoY { get; set; }
        short OrigenX { get; set; }
        short OrigenY { get; set; }
        short MapaDestino { get; set; }
        short MapaOrigen { get; set; }
        byte AparienciaPortal { get; set; }
    }
}