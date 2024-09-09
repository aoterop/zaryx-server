using Zaryx_Game.Comunicacion.Mensajeria;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes;
using Zaryx_Game.Juego;

namespace Zaryx_Game
{
    public static class Program
    {
        static readonly AutoResetEvent eventoEspera = new(false);

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Inicialización del módulo de juego.

            GestorJuego gestorJuego = GestorJuego.Instancia();

            Task.Run(async () => { await gestorJuego.Inicializar(); }).Wait();

            // Inicialización del módulo de comunicación.

            Console.WriteLine("Iniciando módulo de comunicación...");

            Conector.Instancia.IniciarConector();

            Procesador procesador = new(Buzon.Instancia);
            _ = procesador.ProcesarMensajes(); // Procesamiento de los mensajes.

            ManejadorDeMensajes.Instancia.RegistrarGestores();


            Task escuchaConector = Conector.Instancia.EscuchaReceptor();

            //Console.Beep(); // ¡Todo está listo!

            eventoEspera.WaitOne();
        }
    }
}