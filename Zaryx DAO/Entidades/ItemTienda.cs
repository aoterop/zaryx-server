using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemTienda : IItemTienda
    {
        private int _idItemTienda;
        private int _puestoDeVenta;
        private short _itemOfertado;

        public int IdItemTienda { get { return _idItemTienda; } set { _idItemTienda = value; } }
        public int PuestoDeVenta { get { return _puestoDeVenta; } set { _puestoDeVenta = value; } }
        public short ItemOfertado { get { return _itemOfertado; } set { _itemOfertado = value; } }
    }
}