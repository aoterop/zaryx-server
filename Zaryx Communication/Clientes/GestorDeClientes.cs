using System.Net.Sockets;
using System.Text;
using Zaryx_Communication.Interna;
using Zaryx_Game.General;

namespace Zaryx_Communication.Clientes
{
    internal class GestorDeClientes
    {
        // Singleton.
        private static readonly GestorDeClientes _instancia = new();

        // Diccionario de clientes.
        public readonly Dictionary<byte, Cliente> clientes;
        private static readonly object locker = new();
        private static byte nextId = 0;

        public static GestorDeClientes Instancia { get { return _instancia; } }

        private GestorDeClientes()
        { 
            clientes = new Dictionary<byte, Cliente>();
        }

        public void CerrarConexiones()
        {
            lock(locker)
            {
                Console.WriteLine("hay un total de " + clientes.Count + " clientes dentro del sistema.");
                foreach(Cliente c in clientes.Values)
                {
                    if(c != null)
                    {
                        EnviarMensaje("OFF", c.IdCliente); // Leerá 0 bytes, lo cual cerrará su conexión.
                        EliminarCliente(c.IdCliente);
                        ConectorInterno.Instancia.EnviarMensaje(c.IdCliente + "§" + (byte)Tipos.MensajeEntrante.ME_CIERRE_SESION + "§" + "");
                    }
                }
            }
        }

        public Cliente? AgregarCliente(TcpClient tcpCliente)
        {
            Cliente? cliente = null;

            lock (locker) 
            {
                cliente = new Cliente(nextId, tcpCliente);
                clientes.Add(nextId, cliente);
                nextId++;
            }

            return cliente;
        }

        public void EliminarCliente(byte idCliente)
        {
            lock (locker)
            {
                clientes[idCliente].CerrarConexion();
                clientes.Remove(idCliente);
            }        
        }

        public void EnviarMensaje(string mensaje, byte idCliente)
        {
            lock(locker)
            {
                if (clientes.ContainsKey(idCliente))
                {
                    TcpClient cliente = clientes[idCliente].ConexionTcp!;

                    if (cliente != null && cliente.Connected)
                    {
                        byte[] bytesMensaje = Encoding.UTF8.GetBytes(mensaje);
                        int longitudMensaje = bytesMensaje.Length;
                        byte[] buffer = new byte[2 + longitudMensaje];
                        byte[] cabecera = BitConverter.GetBytes(longitudMensaje);
                        Array.Copy(cabecera, buffer, 2);
                        Array.Copy(bytesMensaje, 0, buffer, 2, longitudMensaje);
            
                        cliente.GetStream().Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}