using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Tienda : ITienda
    {
        private int _idTienda;
        private string? _nombreTienda = "";
        private byte _ratioCompra;
        private string? _nombreNpc = "";
        private byte _orientacionNpc;
        private short _tiendaX;
        private short _tiendaY;
        private short _mapaTienda;

        public int IdTienda { get { return _idTienda; } set { _idTienda = value; } }
        public string? NombreTienda { get { return _nombreTienda; } set { _nombreTienda = value; } }
        public byte RatioCompra { get { return _ratioCompra; } set { _ratioCompra = value; } }
        public string? NombreNpc { get { return _nombreNpc; } set { _nombreNpc = value; } }
        public byte OrientacionNpc { get { return _orientacionNpc; } set { _orientacionNpc = value; } }
        public short TiendaX { get { return _tiendaX; } set { _tiendaX = value; } }
        public short TiendaY { get { return _tiendaY; } set { _tiendaY = value; } }
        public short MapaTienda { get { return _mapaTienda; } set { _mapaTienda = value; } }
    }
}