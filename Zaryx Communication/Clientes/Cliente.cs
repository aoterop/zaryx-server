using System.Net.Sockets;

namespace Zaryx_Communication.Clientes
{
    internal class Cliente
    {
        public byte IdCliente { get; set; } // IdSesion.
        public TcpClient? ConexionTcp { get; set; }

        public Cliente(byte idCliente, TcpClient? conexionTcp)
        {
            IdCliente = idCliente;
            ConexionTcp = conexionTcp;
        }

        public void CerrarConexion()
        {
            if(ConexionTcp != null)
            {
                ConexionTcp.Dispose();
                ConexionTcp.Close();
            }
        }
    }
}