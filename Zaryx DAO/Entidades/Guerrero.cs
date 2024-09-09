using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Guerrero : IGuerrero
    {
        private long _idPersonaje;
        private long _cuentaAsociada;
        private string _nombrePersonaje = "";
        private byte _peinado;
        private byte _aspectoFacial;
        private bool _esAdmin;
        private int _tiempoJugado;
        private int _ultimoHp;
        private int _ultimoMp;
        private long _monedas;
        private byte _nivelPersonaje;
        private short _ultimoMapa;
        private short _ultimoMapaX;
        private short _ultimoMapaY;
        private long _experienciaPersonaje;
        private bool _estaSilenciado;

        public long IdPersonaje { get { return _idPersonaje; } set { _idPersonaje = value; } }
        public long CuentaAsociada { get { return _cuentaAsociada; } set { _cuentaAsociada = value; } }
        public string NombrePersonaje { get { return _nombrePersonaje; } set { _nombrePersonaje = value; } }
        public byte Peinado { get { return _peinado; } set { _peinado = value; } }
        public byte AspectoFacial { get { return _aspectoFacial; } set { _aspectoFacial = value; } }
        public bool EsAdmin { get { return _esAdmin; } set { _esAdmin = value; } }
        public int TiempoJugado { get { return _tiempoJugado; } set { _tiempoJugado = value; } }
        public int UltimoHp { get { return _ultimoHp; } set { _ultimoHp = value; } }
        public int UltimoMp { get { return _ultimoMp; } set { _ultimoMp = value; } }
        public long Monedas { get { return _monedas; } set { _monedas = value; } }
        public byte NivelPersonaje { get { return _nivelPersonaje; } set { _nivelPersonaje = value; } }
        public short UltimoMapa { get { return _ultimoMapa; } set { _ultimoMapa = value; } }
        public short UltimoMapaX { get { return _ultimoMapaX; } set { _ultimoMapaX = value; } }
        public short UltimoMapaY { get { return _ultimoMapaY; } set { _ultimoMapaY = value; } }
        public long ExperienciaPersonaje { get { return _experienciaPersonaje; } set { _experienciaPersonaje = value; } }
        public bool EstaSilenciado { get { return _estaSilenciado; } set { _estaSilenciado = value; } }
    }
}