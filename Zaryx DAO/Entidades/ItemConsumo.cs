using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemConsumo : Item, IItemConsumo
    {
        private short _curaHp;
        private short _curaMp;

        public short CuraHp { get { return _curaHp; } set { _curaHp = value; } }
        public short CuraMp { get { return _curaMp; } set { _curaMp = value; } }
    }
}