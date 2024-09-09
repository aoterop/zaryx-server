using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Buff : IBuff
    {
        private short _idBuff;
        private string _nombreBuff = "";
        private string? _detallesBuff;
        private int _duracionBuff;
        private short _aumentoVelocidad;
        private short _aumentoDefensa;
        private short _aumentoAtaque;
        private bool _antiCritico;
        private bool _inmortalidad;
        private bool _inmovilidad;
        private bool _shock;
        private short? _siguienteBuff;

        public short IdBuff { get { return _idBuff; } set { _idBuff = value; } }
        public string NombreBuff { get { return _nombreBuff; } set { _nombreBuff = value; } }
        public string? DetallesBuff { get { return _detallesBuff; } set { _detallesBuff = value; } }
        public int DuracionBuff { get { return _duracionBuff; } set { _duracionBuff = value; } }
        public short AumentoVelocidad { get { return _aumentoVelocidad; } set { _aumentoVelocidad = value; } }
        public short AumentoDefensa { get { return _aumentoDefensa; } set { _aumentoDefensa = value; } }
        public short AumentoAtaque { get { return _aumentoAtaque; } set { _aumentoAtaque = value; } }
        public bool AntiCritico { get { return _antiCritico; } set { _antiCritico = value; } }
        public bool Inmortalidad { get { return _inmortalidad; } set { _inmortalidad = value; } }
        public bool Inmovilidad { get { return _inmovilidad; } set { _inmovilidad = value; } }
        public bool Shock { get { return _shock; } set { _shock = value; } }
        public short? SiguienteBuff { get { return _siguienteBuff; } set { _siguienteBuff = value; } }
    }
}