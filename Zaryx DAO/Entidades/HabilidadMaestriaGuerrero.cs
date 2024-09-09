using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class HabilidadMaestriaGuerrero : Habilidad, IHabilidadMaestriaGuerrero
    {
        private byte _nivelMasterMin;
        private byte _maestria;

        public byte NivelMasterMin { get { return _nivelMasterMin; } set { _nivelMasterMin = value; } }
        public byte Maestria { get { return _maestria; } set { _maestria = value; } }
    }
}