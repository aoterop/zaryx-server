using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemMiscelanea : Item, IItemMiscelanea
    {
        private byte _nivelRequerido;

        public byte NivelRequerido { get { return _nivelRequerido; } set { _nivelRequerido = value; } }
    }
}