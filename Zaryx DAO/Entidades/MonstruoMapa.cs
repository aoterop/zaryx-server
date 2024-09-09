using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class MonstruoMapa : IMonstruoMapa
    {
        private int _idMonstruoMapa;
        private short _referenciaMapa;
        private short _referenciaMonstruo;
        private short _posicionX;
        private short _posicionY;
        private byte _orientacionMonstruo;
        private bool _puedeMoverse;

        public int IdMonstruoMapa { get { return _idMonstruoMapa; } set { _idMonstruoMapa = value; } }
        public short ReferenciaMapa { get { return _referenciaMapa; } set { _referenciaMapa = value; } }
        public short ReferenciaMonstruo { get { return _referenciaMonstruo; } set { _referenciaMonstruo = value; } }
        public short PosicionX { get { return _posicionX; } set { _posicionX = value; } }
        public short PosicionY { get { return _posicionY; } set { _posicionY = value; } }
        public byte OrientacionMonstruo { get { return _orientacionMonstruo; } set { _orientacionMonstruo = value; } }
        public bool PuedeMoverse { get { return _puedeMoverse; } set { _puedeMoverse = value; } }
    }
}