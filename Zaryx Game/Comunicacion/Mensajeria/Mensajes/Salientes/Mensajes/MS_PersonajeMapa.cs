using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_PersonajeMapa : IMensajeSaliente
    {
        public Guerrero GuerreroMapa { get; set; }
        public Tirador TiradorMapa { get; set; }
        public List<Nodo> Nodos { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_PERSONAJES_MAPA; }

        public MS_PersonajeMapa(Guerrero guerrerosMapa, Tirador tiradoresMapa, List<Nodo> nodos)
        {
            GuerreroMapa = guerrerosMapa;
            TiradorMapa = tiradoresMapa;
            Nodos = nodos;
        }
    }
}