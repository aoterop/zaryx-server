using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Portales;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_PortalesMapa : IMensajeSaliente
    {
        public List<Portal> Portales { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_PORTALES_MAPA; }

        public MS_PortalesMapa(List<Portal> portales)
        {
            Portales = portales;
        }
    }
}