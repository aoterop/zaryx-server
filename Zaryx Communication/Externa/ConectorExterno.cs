using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Zaryx_Communication.Clientes;
using Zaryx_Communication.Interna;
using Zaryx_Game.General;

namespace Zaryx_Communication.Externa
{
    internal class ConectorExterno
    {
        // Singleton.
        private static readonly ConectorExterno _instancia = new();

        private TcpListener? Conexion { get; set; }
        private int PuertoConexion { get; set; }
        private ConectorExterno() { }
        public static ConectorExterno Instancia { get { return _instancia; } }

        public void IniciarConector()
        {
            PuertoConexion = int.Parse(ConfigurationManager.AppSettings["PuertoConectorExterno"]!);
            Conexion = new TcpListener(IPAddress.Parse(ConfigurationManager.AppSettings["IpServidorExterno"]!), PuertoConexion);

            if (Conexion != null)
            {
                Conexion.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Servidor Zaryx iniciado en el puerto " + PuertoConexion.ToString());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se ha podido iniciar el servidor de comunicación.");
            }
        }

        public async Task EscuchaReceptor()
        {
            while (true)
            {
                TcpClient nuevoCliente = await Conexion!.AcceptTcpClientAsync();

                Cliente? c = GestorDeClientes.Instancia.AgregarCliente(nuevoCliente);

                if (c != null)
                {
                    _ = ManejarCliente(c);
                }
            }
        }

        private static async Task ManejarCliente(Cliente cliente)
        {
            // NetworkStream del cliente para enviar y recibir datos
            NetworkStream stream = cliente.ConexionTcp!.GetStream();

            ushort longitudMensaje;
            byte[] headerBuffer = new byte[2];
            byte[] buffer;

            // Registrar la sesión.
            ConectorInterno.Instancia.EnviarMensaje(cliente.IdCliente + "§" + (byte)Tipos.MensajeEntrante.ME_REGISTRAR_SESION + "§" + "");


            // Bucle para escuchar y procesar los mensajes del cliente
            while (cliente.ConexionTcp!.Connected)
            {
                // Lee los datos del cliente.

                // Lee la longitud del mensaje:
                await stream.ReadAsync(headerBuffer, 0, 2);
                longitudMensaje = BitConverter.ToUInt16(headerBuffer, 0);

                // Lee el contenido del mensaje a partir de su longitud:

                buffer = new byte[longitudMensaje];
                int bytesRead = await stream.ReadAsync(buffer, 0, longitudMensaje);
                                
                if (bytesRead > 0)
                {// Se procesa el mensaje recibido:
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ConectorInterno.Instancia.EnviarMensaje(cliente.IdCliente + "§" + mensaje);
                }
                else
                {
                    break;
                }
            }

            // El cliente se ha desconectado.
            // Envía un mensaje mediante el conector interno a la capa de comunicación del proyecto de juego.
            ConectorInterno.Instancia.EnviarMensaje(cliente.IdCliente + "§" + (byte)Tipos.MensajeEntrante.ME_CIERRE_SESION + "§" + "");
            // Se elimina el cliente.
            GestorDeClientes.Instancia.EliminarCliente(cliente.IdCliente);
        }

        public void CerrarConexiones()
        {
            GestorDeClientes.Instancia.CerrarConexiones();
        }
    }
}