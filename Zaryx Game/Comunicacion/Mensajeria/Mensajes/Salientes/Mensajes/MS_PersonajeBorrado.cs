using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_PersonajeBorrado : IMensajeSaliente
    {
        public long IdPersonaje { get; set; }
        public bool Borrado { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_PERSONAJE_BORRADO; }

        public MS_PersonajeBorrado(long idPersonaje, bool borrado)
        {
            IdPersonaje = idPersonaje;
            Borrado = borrado;
        }
    }
}