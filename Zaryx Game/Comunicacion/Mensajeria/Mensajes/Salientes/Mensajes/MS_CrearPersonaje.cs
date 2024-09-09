using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Mensajes.Salientes.Mensajes
{
    public class MS_CrearPersonaje : IMensajeSaliente
    {
        public bool NombreEnUso { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_CREAR_PERSONAJE; }

        public MS_CrearPersonaje(bool nombreEnUso)
        {
            NombreEnUso = nombreEnUso;
        }
    }
}