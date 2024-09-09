using Zaryx_Game.Juego.Modelos.Mapas;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_MovimientoPersonaje
    {
        public List<Nodo>? Nodos { get; set; }
        public short IdMapa { get; set; }

        public ME_MovimientoPersonaje() { }
    }
}