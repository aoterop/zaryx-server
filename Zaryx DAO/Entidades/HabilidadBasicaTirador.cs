using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class HabilidadBasicaTirador : Habilidad, IHabilidadBasicaTirador
    {
        private bool _requiereObjetivo;
        private byte _nivelRequerido;

        public bool RequiereObjetivo { get { return _requiereObjetivo; } set { _requiereObjetivo = value; } }
        public byte NivelRequerido { get { return _nivelRequerido; } set { _nivelRequerido = value; } }
    }
}