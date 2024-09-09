using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class HabilidadBasicaGuerreroRelacion : IHabilidadBasicaGuerreroRelacion
    {
        private int _idHabilidadGuerrero;
        private long _refGuerrero;
        private short _habilidadAprendida;

        public int IdHabilidadGuerrero { get { return _idHabilidadGuerrero; } set { _idHabilidadGuerrero = value; } }
        public long RefGuerrero { get { return _refGuerrero; } set { _refGuerrero = value; } }
        public short HabilidadAprendida { get { return _habilidadAprendida; } set { _habilidadAprendida = value; } }
    }
}