using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class PortalDTO
    {
        public int IdPortal { get; set; }
        public short DestinoX { get; set; }
        public short DestinoY { get; set; }
        public short OrigenX { get; set; }
        public short OrigenY { get; set; }
        public short MapaDestino { get; set; }
        public short MapaOrigen { get; set; }
        public byte AparienciaPortal { get; set; }

        public PortalDTO(IPortal portal)
        {
            this.IdPortal = portal.IdPortal;
            this.DestinoX = portal.DestinoX;
            this.DestinoY = portal.DestinoY;
            this.OrigenX = portal.OrigenX;
            this.OrigenY = portal.OrigenY;
            this.MapaDestino = portal.MapaDestino;
            this.MapaOrigen = portal.MapaOrigen;
            this.AparienciaPortal = portal.AparienciaPortal;
        }
    }
}