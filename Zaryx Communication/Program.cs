using Zaryx_Communication.Externa;
using Zaryx_Communication.Interna;

internal class ZaryxCommunication
{
    static readonly AutoResetEvent eventoEspera = new(false);

    static void Main()
    {
        Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit!);

        Console.ForegroundColor = ConsoleColor.Yellow;

        ConectorInterno.Instancia.IniciarConectorInterno();

        _ = new Procesador(BandejaDeSalida.Instancia);

        _ = ConectorInterno.Instancia.EscucharMensajesAsync();

        ConectorExterno.Instancia.IniciarConector();

        _ = ConectorExterno.Instancia.EscuchaReceptor();

        eventoEspera.WaitOne();
    }

    protected static void OnExit(object sender, ConsoleCancelEventArgs args)
    {
        args.Cancel = true;
        ConectorExterno.Instancia.CerrarConexiones();
        Environment.Exit(0);
    }
}