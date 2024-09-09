using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Portal : IPortal
    {
        private int _idPortal;
        private short _destinoX;
        private short _destinoY;
        private short _origenX;
        private short _origenY;
        private short _mapaDestino;
        private short _mapaOrigen;
        private byte _aparienciaPortal;

        public int IdPortal { get { return _idPortal; } set { _idPortal = value; } }
        public short DestinoX { get { return _destinoX; } set { _destinoX = value; } }
        public short DestinoY { get { return _destinoY; } set { _destinoY = value; } }
        public short OrigenX { get { return _origenX; } set { _origenX = value; } }
        public short OrigenY { get { return _origenY; } set { _origenY = value; } }
        public short MapaDestino { get { return _mapaDestino; } set { _mapaDestino = value; } }
        public short MapaOrigen { get { return _mapaOrigen; } set { _mapaOrigen = value; } }
        public byte AparienciaPortal { get { return _aparienciaPortal; } set { _aparienciaPortal = value; } }
    }
}