using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemGuerrero : IItemGuerrero
    {
        private long _idItemGuerrero;
        private long _propietario;
        private short _referenciaItem;
        private short _cantidad;
        private byte _nivelItem;
        private long _experienciaItem;
        private byte _ranuraInventario;

        public long IdItemGuerrero { get { return _idItemGuerrero; } set { _idItemGuerrero = value; } }
        public long Propietario { get { return _propietario; } set { _propietario = value; } }
        public short ReferenciaItem { get { return _referenciaItem; } set { _referenciaItem = value; } }
        public short Cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public byte NivelItem { get { return _nivelItem; } set { _nivelItem = value; } }
        public long ExperienciaItem { get { return _experienciaItem; } set { _experienciaItem = value; } }
        public byte RanuraInventario { get { return _ranuraInventario; } set { _ranuraInventario = value; } }
    }
}