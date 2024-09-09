using Zaryx_Communication.Clientes;

namespace Zaryx_Communication.Interna
{
    internal class Procesador
    {
        private readonly BandejaDeSalida bandejaSalida;
        private bool procesando;


        public Procesador(BandejaDeSalida bandejaSalida)
        {
            this.bandejaSalida = bandejaSalida;
            this.bandejaSalida.NuevoMensaje += EnviarSiguienteMensaje!;
            this.procesando = false;
        }

        private void EnviarSiguienteMensaje(object sender, EventArgs e)
        {
            lock (this) // Exclusión mutua
            {
                if (!procesando)
                {
                    procesando = true;
                    EnviarMensajesEnCola();
                }
            }
        }

        private void EnviarMensajesEnCola()
        {
            while(bandejaSalida.HayMensajesEnCola())
            {
                string mensaje = bandejaSalida.ObtenerSiguienteMensaje();

                // Buscar el índice del carácter "§" en la cadena
                int indiceSeparador = mensaje.IndexOf("§");

                if (indiceSeparador != -1)
                {
                    // Extraer la parte numérica antes del separador
                    string idCliente = mensaje.Substring(0, indiceSeparador);

                    byte id = byte.Parse(idCliente);

                    GestorDeClientes.Instancia.EnviarMensaje(mensaje.Substring(indiceSeparador + 1), id);
                }
            }

            lock (this) // Exclusión mutua
            {
                procesando = false;
            }
        }
    }
}