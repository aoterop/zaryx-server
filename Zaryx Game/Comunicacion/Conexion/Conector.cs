using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Configuration;
using Zaryx_Game.Comunicacion.Mensajeria;

namespace Zaryx_Game.Comunicacion.Conexion
{
    internal class Conector
    {
        // Singleton.
        private static readonly Conector _instancia = new();
        private TcpListener? Conexion { get; set; }
        private TcpClient? ZaryxCommunication { get; set; }
        private int PuertoConexion { get; set; }
        private Conector() { }
        public static Conector Instancia { get { return _instancia; } }

        public void IniciarConector()
        {
            PuertoConexion = int.Parse(ConfigurationManager.AppSettings["PuertoConector"]!);
            Conexion = new TcpListener(IPAddress.Parse(ConfigurationManager.AppSettings["IpConector"]!), PuertoConexion);

            if (Conexion != null)
            {
                Conexion.Start();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Conexión con [Zaryx Communication] iniciada en el puerto " + PuertoConexion.ToString());
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se ha podido iniciar el conector con [Zaryx Communication]");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        public async Task EscuchaReceptor()
        {
            ZaryxCommunication = await Conexion!.AcceptTcpClientAsync();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("¡Conexión con [Zaryx Communication] exitosa!");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Obtener el flujo de red para enviar y recibir datos
            NetworkStream stream = ZaryxCommunication.GetStream();

            // Leer datos del cliente
            ushort longitudMensaje;
            byte[] headerBuffer = new byte[2];
            byte[] buffer;

            while (true)
            {
                await stream.ReadAsync(headerBuffer, 0, 2);
                longitudMensaje = BitConverter.ToUInt16(headerBuffer, 0);
                
                buffer = new byte[longitudMensaje];
                
                int bytesRead = await stream.ReadAsync(buffer, 0, longitudMensaje);

                if(bytesRead == 0) { break; }
                Buzon.Instancia.AgregarMensaje(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }

            Console.WriteLine("La conexión con [Zaryx Communication] se ha vencido");
            ZaryxCommunication.Close();
            Conexion.Stop();
        }

        public void EnviarMensaje(string mensaje)
        {// mensaje: idSesion,message

            byte[] bytesMensaje = Encoding.UTF8.GetBytes(mensaje);
            int longitudMensaje = bytesMensaje.Length;
            byte[] buffer = new byte[2 + longitudMensaje];
            byte[] cabecera = BitConverter.GetBytes(longitudMensaje);
            Array.Copy(cabecera, buffer, 2);
            Array.Copy(bytesMensaje, 0, buffer, 2, longitudMensaje);

            ZaryxCommunication!.GetStream().Write(buffer, 0, buffer.Length);
        }
    }
}