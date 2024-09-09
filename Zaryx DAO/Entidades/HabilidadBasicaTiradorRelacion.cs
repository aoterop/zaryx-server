using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class HabilidadBasicaTiradorRelacion : IHabilidadBasicaTiradorRelacion
    {
        private int _idHabilidadTirador;
        private long _refTirador;
        private short _habilidadAdquirida;

        public int IdHabilidadTirador { get { return _idHabilidadTirador; } set { _idHabilidadTirador = value; } }
        public long RefTirador { get { return _refTirador; } set { _refTirador = value; } }
        public short HabilidadAdquirida { get { return _habilidadAdquirida; } set { _habilidadAdquirida = value; } }
    }
}