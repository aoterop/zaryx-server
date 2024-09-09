using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class MaestriaGuerrero : Item, IMaestriaGuerrero
    {
        private byte _nivelMinimo;
        private byte _numeroMaestria;

        public byte NivelMinimo { get { return _nivelMinimo; } set { _nivelMinimo = value; } }
        public byte NumeroMaestria { get { return _numeroMaestria; } set { _numeroMaestria = value; } }
    }
}