using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_MovimientoPersonaje : IMensajeSaliente
    {
        public List<Nodo>? Nodos { get; set; }
        public long IdPersonaje { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_MOVIMIENTO_PERSONAJE; }

        public MS_MovimientoPersonaje(List<Nodo> nodos, long idPersonaje)
        {
            Nodos = nodos;
            IdPersonaje = idPersonaje;
        }
    }
}