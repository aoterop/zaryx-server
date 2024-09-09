using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Monstruo : IMonstruo
    {
        private short _idMonstruo;
        private string _nombreMonstruo = "";
        private string? _detallesMonstruo;
        private int _tiempoReaparicion;
        private byte _velocidadMonstruo;
        private int _aumentoExperiencia;
        private byte _nivelMonstruo;
        private int _maxHpMonstruo;
        private int _maxMpMonstruo;
        private short _ataqueMinMonstruo;
        private short _ataqueMaxMonstruo;
        private short _defensaMonstruo;
        private bool _esAgresivo;

        public short IdMonstruo { get { return _idMonstruo; } set { _idMonstruo = value; } }
        public string NombreMonstruo { get { return _nombreMonstruo; } set { _nombreMonstruo = value; } }
        public string? DetallesMonstruo { get { return _detallesMonstruo; } set { _detallesMonstruo = value; } }
        public int TiempoReaparicion { get { return _tiempoReaparicion; } set { _tiempoReaparicion = value; } }
        public byte VelocidadMonstruo { get { return _velocidadMonstruo; } set { _velocidadMonstruo = value; } }
        public int AumentoExperiencia { get { return _aumentoExperiencia; } set { _aumentoExperiencia = value; } }
        public byte NivelMonstruo { get { return _nivelMonstruo; } set { _nivelMonstruo = value; } }
        public int MaxHpMonstruo { get { return _maxHpMonstruo; } set { _maxHpMonstruo = value; } }
        public int MaxMpMonstruo { get { return _maxMpMonstruo; } set { _maxMpMonstruo = value; } }
        public short AtaqueMinMonstruo { get { return _ataqueMinMonstruo; } set { _ataqueMinMonstruo = value; } }
        public short AtaqueMaxMonstruo { get { return _ataqueMaxMonstruo; } set { _ataqueMaxMonstruo = value; } }
        public short DefensaMonstruo { get { return _defensaMonstruo; } set { _defensaMonstruo = value; } }
        public bool EsAgresivo { get { return _esAgresivo; } set { _esAgresivo = value; } }
    }
}