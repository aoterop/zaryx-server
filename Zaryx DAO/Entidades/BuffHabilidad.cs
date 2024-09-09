using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class BuffHabilidad : IBuffHabilidad
    {
        private int _idHabilidadBuff;
        private short _buffProducido;
        private short _habilidadAsociada;
        private int _probabilidadExito;

        public int IdHabilidadBuff { get { return _idHabilidadBuff; } set { _idHabilidadBuff = value; } }
        public short BuffProducido { get { return _buffProducido; } set { _buffProducido = value; } }
        public short HabilidadAsociada { get { return _habilidadAsociada; } set { _habilidadAsociada = value; } }
        public int ProbabilidadExito { get { return _probabilidadExito; } set { _probabilidadExito = value; } }
    }
}