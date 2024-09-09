using System.Configuration;
using Zaryx_Game.Autenticacion.Sesiones;

namespace Zaryx_Game.Autenticacion
{
    internal class GestorDeSesiones
    {
        // Singleton.
        private static readonly GestorDeSesiones _instancia = new();

        // Lista de sesiones activas.
        private readonly static Dictionary<byte, Sesion> sesiones = new();
        private static readonly object locker = new();
        private readonly static SemaphoreSlim semaforo = new(1, 1);

        public static GestorDeSesiones Instancia() { return _instancia; }

        private GestorDeSesiones() { }

        public async Task CrearSesion(byte idSesion)
        {
            await semaforo.WaitAsync();

            try
            {
                Sesion nuevaSesion = new(idSesion);
                AgregarSesion(nuevaSesion);
            }
            finally
            {
                semaforo.Release();
            }
        }

        private void AgregarSesion(Sesion nuevaSesion)
        {
            lock (locker)
            {
                if (!ExisteSesionConId(nuevaSesion.IdSesion) && sesiones.Count <= int.Parse(ConfigurationManager.AppSettings["SesionesMaximas"]!))
                {
                    sesiones[nuevaSesion.IdSesion] = nuevaSesion;
                }
            }
        }

        public void EliminarSesion(byte idSesion)
        {
            lock (locker)
            {
                sesiones.Remove(idSesion);
            }
        }

        public bool ExisteSesionConId(byte idSesion)
        {
            lock (locker)
            {
                return sesiones.ContainsKey(idSesion);
            }
        }

        public Sesion? ObtenerSesion(byte idSesion)
        {
            lock (locker)
            {
                sesiones.TryGetValue(idSesion, out Sesion? sesion);
                return sesion;
            }
        }
    }
}