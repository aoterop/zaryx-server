using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemBuff : IItemBuff
    {
        private int _idItemBuff;
        private short _itemGenerador;
        private short _buffGenerador;
        private bool _esGrupal;

        public int IdItemBuff { get { return _idItemBuff; } set { _idItemBuff = value; } }
        public short ItemGenerador { get { return _itemGenerador; } set { _itemGenerador = value; } }
        public short BuffGenerador { get { return _buffGenerador; } set { _buffGenerador = value; } }
        public bool EsGrupal { get { return _esGrupal; } set { _esGrupal = value; } }
    }
}