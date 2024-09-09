using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Autenticacion.Sesiones
{
    public class Sesion
    {
        public Queue<string> Mensajes { get; set; }

        public CuentaDTO? Cuenta { get; set; }
        public byte IdSesion { get; set; }

        private readonly SemaphoreSlim semaforo;
        private readonly object locker;

        public Sesion(byte idSesion)
        {
            locker = new object();
            IdSesion = idSesion;
            Mensajes = new Queue<string>();
            semaforo = new SemaphoreSlim(0, 1); // Valor inicial: 0. Capacidad máximo: 1.
        }

        public void EstablecerCuenta(CuentaDTO cuenta)
        {
            Cuenta = cuenta;
        }

        public void AgregarMensaje(string mensaje)
        {
            lock(locker)
            {
                Mensajes.Enqueue(mensaje);
            }

            semaforo.Release();
        }

        public async Task ProcesarMensajes()
        {
            string[] partesMensaje;

            while (true) // Cambiar esto.
            {
                await semaforo.WaitAsync();
                while(Mensajes.TryDequeue(out var mensaje)) 
                {
                    partesMensaje = mensaje.Split('§');
                    await ManejadorDeMensajes.Instancia.ManejarMensaje(this, byte.Parse(partesMensaje[1]), partesMensaje[2]);
                }
            }
        }
    }
}