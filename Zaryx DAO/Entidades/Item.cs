using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Item : IItem
    {
        private short _idItem;
        private string _nombreItem = "";
        private string? _detallesItem;
        private long _precio;
        private bool _esArrojable;

        public short IdItem { get { return _idItem; } set { _idItem = value; } }
        public string NombreItem { get { return _nombreItem; } set { _nombreItem = value; } }
        public string? DetallesItem { get { return _detallesItem; } set { _detallesItem = value; } }
        public long Precio { get { return _precio; } set { _precio = value; } }
        public bool EsArrojable { get { return _esArrojable; } set { _esArrojable = value; } }
    }
}