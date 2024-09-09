using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Mensajes.Salientes.Mensajes
{
    public class MS_EnviarPersonajes : IMensajeSaliente
    {
        
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.ENVIAR_PERSONAJES; }
    }
}