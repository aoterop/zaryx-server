using System.Collections.Concurrent;
using Zaryx_Game.Estructuras;
using Zaryx_Game.Juego.Modelos.Mapas;

namespace Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador
{
    internal class TiradorEntidadCombate : IEntidadCombate
    {

        #region Miembros

        private readonly object locker = new();

        private readonly Random _aleatoriedad;
        private string? _nombre;
        private int _hp;
        private int _mp;
        private int _maxHp;
        private int _maxMp;
        private short _mapa;
        private short _x;
        private short _y;
        private long _experienciaQueOtorga;
        private long _experiencia;
        private byte _nivel;
        private byte _velocidad;
        private short _ataqueMin;
        private short _ataqueMax;
        private short _defensa;
        private short _ratioCritico;
        private short _ataqueCritico;
        private bool _inmortal; // Protege frende daño de ataque.
        private bool _enShock; // Impide atacar si está a true.
        private bool _antiCriticos;
        private bool _inmovilizado; // Impide el movimiento, pero no atacar.
        private bool _enCombate;

        #endregion

        #region Propiedades
        public string? Nombre
        {
            get { lock (locker) { return _nombre; } }
            set { lock (locker) { _nombre = value; } }
        }

        public int Hp
        {
            get { lock (locker) { return _hp; } }
            set { lock (locker) { _hp = value; } }
        }

        public int Mp
        {
            get { lock (locker) { return _mp; } }
            set { lock (locker) { _mp = value; } }
        }

        public int MaxHp
        {
            get { lock (locker) { return _maxHp; } }
            set { lock (locker) { _maxHp = value; } }
        }

        public int MaxMp
        {
            get { lock (locker) { return _maxMp; } }
            set { lock (locker) { _maxMp = value; } }
        }

        public short Mapa
        {
            get { lock (locker) { return _mapa; } }
            set { lock (locker) { _mapa = value; } }
        }

        public short X
        {
            get { lock (locker) { return _x; } }
            set { lock (locker) { _x = value; } }
        }

        public short Y
        {
            get { lock (locker) { return _y; } }
            set { lock (locker) { _y = value; } }
        }

        public long ExperienciaQueOtorga
        {
            get { lock (locker) { return _experienciaQueOtorga; } }
            set { lock (locker) { _experienciaQueOtorga = value; } }
        }

        public long Experiencia
        {
            get { lock (locker) { return _experiencia; } }
            set { lock (locker) { _experiencia = value; } }
        }

        public byte Nivel
        {
            get { lock (locker) { return _nivel; } }
            set { lock (locker) { _nivel = value; } }
        }

        public byte Velocidad
        {
            get { lock (locker) { return _velocidad; } }
            set { lock (locker) { _velocidad = value; } }
        }

        public short AtaqueMin
        {
            get { lock (locker) { return _ataqueMin; } }
            set { lock (locker) { _ataqueMin = value; } }
        }

        public short AtaqueMax
        {
            get { lock (locker) { return _ataqueMax; } }
            set { lock (locker) { _ataqueMax = value; } }
        }

        public short Defensa
        {
            get { lock (locker) { return _defensa; } }
            set { lock (locker) { _defensa = value; } }
        }

        public short RatioCritico
        {
            get { lock (locker) { return _ratioCritico; } }
            set { lock (locker) { _ratioCritico = value; } }
        }

        public short AtaqueCritico
        {
            get { lock (locker) { return _ataqueCritico; } }
            set { lock (locker) { _ataqueCritico = value; } }
        }

        public bool Inmortal
        {
            get { lock (locker) { return _inmortal; } }
            set { lock (locker) { _inmortal = value; } }
        } // Protege frende daño de ataque.

        public bool EnShock
        {
            get { lock (locker) { return _enShock; } }
            set { lock (locker) { _enShock = value; } }
        } // Impide atacar si está a true.

        public bool AntiCriticos
        {
            get { lock (locker) { return _antiCriticos; } }
            set { lock (locker) { _antiCriticos = value; } }
        }

        public bool Inmovilizado
        {
            get { lock (locker) { return _inmovilizado; } }
            set { lock (locker) { _inmovilizado = value; } }
        } // Impide el movimiento, pero no atacar.

        public bool EnCombate
        {
            get { lock (locker) { return _enCombate; } }
            set { lock (locker) { _enCombate = value; } }
        }

        public ListaSegura<Nodo> NodosPorRecorrer { get; set; }

        public ConcurrentDictionary<short, IDisposable> BuffsObservables { get; set; }
        //ConcurrentDictionary<short, Buff> Buffs { get; set; }
        //ConcurrentDictionary<short, IHabilidad> Habilidades { get; set; }
        public ConcurrentDictionary<short, IDisposable> Cooldowns { get; set; }

        // Propiedades de personaje
        public byte IdSesion { get; set; }

        #endregion


        public TiradorEntidadCombate(byte idSesion, string? nombre, int hp, int mp, short mapa, short x, short y, byte nivel, long exp)
        {
            IdSesion = idSesion;
            Nombre = nombre;
            Hp = hp;
            Mp = mp;
            Mapa = mapa;
            X = x;
            Y = y;
            Experiencia = exp;
            ExperienciaQueOtorga = nivel * 100;
            Nivel = nivel;
            Velocidad = 5;

            NodosPorRecorrer = new ListaSegura<Nodo>();
            locker = new object();
            _aleatoriedad = new Random();
            BuffsObservables = new ConcurrentDictionary<short, IDisposable>();
            Cooldowns = new ConcurrentDictionary<short, IDisposable>();
        }
    }
}