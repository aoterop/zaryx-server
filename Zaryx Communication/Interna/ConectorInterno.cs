using System.Net.Sockets;
using System.Text;
using System.Configuration;

namespace Zaryx_Communication.Interna
{
    internal class ConectorInterno
    {
        // Singleton.
        private static readonly ConectorInterno _instancia = new();

        private TcpClient? Cliente { get; set; }
        private NetworkStream? Stream { get; set; }
        private int PuertoConexion { get; set; }
        private ConectorInterno() { }
        public static ConectorInterno Instancia { get { return _instancia; } }

        public void IniciarConectorInterno()
        {
            PuertoConexion = int.Parse(ConfigurationManager.AppSettings["PuertoConectorInterno"]!);

            Cliente = new TcpClient();

            try
            {
                Cliente.Connect(ConfigurationManager.AppSettings["IpServidorInterno"]!, PuertoConexion);

                Stream = Cliente.GetStream();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Conexión con [Zaryx Game] iniciada en el puerto " + PuertoConexion.ToString());
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se ha producido un error en el conector interno: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;

            }

        }

        public void EnviarMensaje(string mensaje)
        {
            byte[] bytesMensaje = Encoding.UTF8.GetBytes(mensaje);
            int longitudMensaje = bytesMensaje.Length;
            byte[] buffer = new byte[2 + longitudMensaje];
            byte[] cabecera = BitConverter.GetBytes(longitudMensaje);
            Array.Copy(cabecera, buffer, 2);
            Array.Copy(bytesMensaje, 0, buffer, 2, longitudMensaje);

            Stream!.Write(buffer, 0, buffer.Length);
        }           

        public async Task EscucharMensajesAsync()
        {
            ushort longitudMensaje;
            byte[] headerBuffer = new byte[2];
            byte[] buffer;


            while (Cliente!.Connected)
            {
                // Recibir mensaje

                await Stream!.ReadAsync(headerBuffer, 0, 2);
                longitudMensaje = BitConverter.ToUInt16(headerBuffer, 0);

                buffer = new byte[longitudMensaje];

                int bytesLeidos = await Cliente.GetStream().ReadAsync(buffer, 0, longitudMensaje);

                if (bytesLeidos > 0)
                {
                    BandejaDeSalida.Instancia.AgregarMensaje(Encoding.UTF8.GetString(buffer, 0, bytesLeidos));
                }            
                else
                {
                    break;
                }
            }

            CerrarConexion();
        }

        public void CerrarConexion()
        {
            Stream!.Close();
            Cliente!.Close();
        }
    }
}