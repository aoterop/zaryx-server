using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Chat;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_NuevoMensajeChat : IMensajeSaliente
    {
        public MensajeChat Mensaje { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_NUEVO_MENSAJE_CHAT; }

        public MS_NuevoMensajeChat(MensajeChat mensaje)
        {
            Mensaje = mensaje;
        }
    }
}