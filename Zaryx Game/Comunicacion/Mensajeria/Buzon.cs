namespace Zaryx_Game.Comunicacion.Mensajeria
{
    internal class Buzon
    {
        // Singleton.
        private static readonly Buzon _instancia = new();

        // Cola de mensajes.
        private readonly Queue<string> buzon;
        private readonly SemaphoreSlim semaforo;
        private static readonly object locker = new();

        private Buzon()
        {
            buzon = new Queue<string>();
            semaforo = new SemaphoreSlim(0);
        }

        public static Buzon Instancia { get { return _instancia; } }

        public void AgregarMensaje(string mensaje)
        {
            lock(locker) // Exclusión mutua para la cola de mensajes
            {
                buzon.Enqueue(mensaje);
            }

            semaforo.Release();
        }
              
        public string ObtenerSiguienteMensaje()
        {
            lock(locker) // Exclusión mutua para la cola de mensajes
            {
                return buzon.Dequeue();
            }
        }

        public async Task EsperarMensaje()
        {
            await semaforo.WaitAsync();
        }
    }
}