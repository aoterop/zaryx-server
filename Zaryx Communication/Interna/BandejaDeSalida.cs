namespace Zaryx_Communication.Interna
{
    internal class BandejaDeSalida
    {
        // Singleton.
        private static readonly BandejaDeSalida _instancia = new();

        // Cola de mensajes.
        private readonly Queue<string> bandejaSalida;
        public event EventHandler? NuevoMensaje;
        private static readonly object locker = new();

        private BandejaDeSalida()
        {
            bandejaSalida = new Queue<string>();
        }

        public static BandejaDeSalida Instancia { get { return _instancia; } }

        public void AgregarMensaje(string mensaje)
        {
            lock (locker) // Exclusión mutua para la cola de mensajes
            {
                bandejaSalida.Enqueue(mensaje);
            }

            OnNuevoMensaje();
        }

        protected virtual void OnNuevoMensaje()
        {
            NuevoMensaje?.Invoke(this, EventArgs.Empty);
        }

        public bool HayMensajesEnCola()
        {
            lock (locker) // Exclusión mutua para la cola de mensajes
            {
                return bandejaSalida.Count > 0;
            }
        }

        public string ObtenerSiguienteMensaje()
        {
            lock (locker) // Exclusión mutua para la cola de mensajes
            {
                return bandejaSalida.Dequeue();
            }
        }
    }
}