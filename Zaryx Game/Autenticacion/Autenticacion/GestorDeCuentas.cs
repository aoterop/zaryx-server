using Zaryx_Game.Autenticacion.Sesiones;

namespace Zaryx_Game.Autenticacion.Autenticacion
{
    internal class GestorDeCuentas
    {
        // Singleton.
        private static readonly GestorDeCuentas _instancia = new();

        // Cuentas activas.
        private readonly static HashSet<long> cuentasActivas = new();
        private readonly static object locker = new();

        private GestorDeCuentas() {}

        public static GestorDeCuentas Instancia() { return _instancia; }

        public void AgregarCuenta(long idCuenta)
        {
            lock(locker)
            {
                cuentasActivas.Add(idCuenta);
            }
        }

        public bool EstaActiva(long idCuenta)
        {
            lock(locker)
            {
                return cuentasActivas.Contains(idCuenta);
            }
        }

        public void EliminarCuenta(long idCuenta)
        {
            lock(locker)
            {
                cuentasActivas.Remove(idCuenta);
            }
        }
    }
}