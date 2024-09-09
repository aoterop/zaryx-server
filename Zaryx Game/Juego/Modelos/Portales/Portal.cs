using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Juego.Modelos.Portales
{
    public class Portal : IPortal
    {
        public int IdPortal { get; set; }
        public short DestinoX { get; set; }
        public short DestinoY { get; set; }
        public short OrigenX { get; set; }
        public short OrigenY { get; set; }
        public short MapaDestino { get; set; }
        public short MapaOrigen { get; set; }
        public byte AparienciaPortal { get; set; }

        public Portal(PortalDTO dto)
        {
            IdPortal = dto.IdPortal;
            DestinoX = dto.DestinoX;
            DestinoY = dto.DestinoY;
            OrigenX = dto.OrigenX;
            OrigenY = dto.OrigenY;
            MapaDestino = dto.MapaDestino;
            MapaOrigen = dto.MapaOrigen;
            AparienciaPortal = dto.AparienciaPortal;
        }
    }
}