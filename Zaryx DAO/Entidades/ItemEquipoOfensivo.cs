using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemEquipoOfensivo : ItemEquipo, IItemEquipoOfensivo
    {
        private short _ratioCritico;
        private short _ataqueCritico;
        private short _ataqueMin;
        private short _ataqueMax;

        public short RatioCritico { get { return _ratioCritico; } set { _ratioCritico = value; } }
        public short AtaqueCritico { get { return _ataqueCritico; } set { _ataqueCritico = value; } }
        public short AtaqueMin { get { return _ataqueMin; } set { _ataqueMin = value; } }
        public short AtaqueMax { get { return _ataqueMax; } set { _ataqueMax = value; } }
    }
}