using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_SalidaPersonaje : IMensajeSaliente
    {
        public long IdPersonaje { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_SALIDA_PERSONAJE; }

        public MS_SalidaPersonaje(long idPersonaje)
        {
            IdPersonaje = idPersonaje;
        }
    }
}