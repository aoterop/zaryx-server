using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemMonstruo : IItemMonstruo
    {
        private short _idItemMonstruo;
        private short _cantidadArrojada;
        private int _probabilidadArrojar;
        private short _itemArrojable;
        private short _monstruoArrojador;

        public short IdItemMonstruo { get { return _idItemMonstruo; } set { _idItemMonstruo = value; } }
        public short CantidadArrojada { get { return _cantidadArrojada; } set { _cantidadArrojada = value; } }
        public int ProbabilidadArrojar { get { return _probabilidadArrojar; } set { _probabilidadArrojar = value; } }
        public short ItemArrojable { get { return _itemArrojable; } set { _itemArrojable = value; } }
        public short MonstruoArrojador { get { return _monstruoArrojador; } set { _monstruoArrojador = value; } }
    }
}