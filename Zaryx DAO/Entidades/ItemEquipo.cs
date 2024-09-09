using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemEquipo : Item, IItemEquipo
    {
        private byte _nivelRequerido;
        private byte _clasePermitida;

        public byte NivelRequerido { get { return _nivelRequerido; } set { _nivelRequerido = value; } }
        public byte ClasePermitida { get { return _clasePermitida; } set { _clasePermitida = value; } }
    }
}