using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class HabilidadMonstruo : Habilidad, IHabilidadMonstruo
    {
        private short _monstruoAsignado;

        public short MonstruoAsignado { get { return _monstruoAsignado; } set { _monstruoAsignado = value; } }
    }
}