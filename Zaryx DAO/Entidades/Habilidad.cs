using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Habilidad : IHabilidad
    {
        private short _idHabilidad;
        private string _nombreHabilidad = "";
        private string? _detallesHabilidad;
        private byte _rangoAlcance;
        private byte _area;
        private short _tiempoCarga;
        private short _duracionHabilidad;
        private short _consumoMp;
        private byte _tipoHabilidad;
        private short _damageBase;

        public short IdHabilidad { get { return _idHabilidad; } set { _idHabilidad = value; } }
        public string NombreHabilidad { get { return _nombreHabilidad; } set { _nombreHabilidad = value; } }
        public string? DetallesHabilidad { get { return _detallesHabilidad; } set { _detallesHabilidad = value; } }
        public byte RangoAlcance { get { return _rangoAlcance; } set { _rangoAlcance = value; } }
        public byte Area { get { return _area; } set { _area = value; } }
        public short TiempoCarga { get { return _tiempoCarga; } set { _tiempoCarga = value; } }
        public short DuracionHabilidad { get { return _duracionHabilidad; } set { _duracionHabilidad = value; } }
        public short ConsumoMp { get { return _consumoMp; } set { _consumoMp = value; } }
        public byte TipoHabilidad { get { return _tipoHabilidad; } set { _tipoHabilidad = value; } }
        public short DamageBase { get { return _damageBase; } set { _damageBase = value; } }
    }
}