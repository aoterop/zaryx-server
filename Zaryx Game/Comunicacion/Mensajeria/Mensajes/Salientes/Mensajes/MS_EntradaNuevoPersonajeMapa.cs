using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_EntradaNuevoPersonajeMapa : IMensajeSaliente
    {
        public Guerrero? GuerreroNuevo { get; set; }
        public Tirador? TiradorNuevo { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_NUEVO_PERSONAJE_MAPA; }

        public MS_EntradaNuevoPersonajeMapa(Guerrero? guerrero, Tirador? tirador)
        {
            GuerreroNuevo = guerrero;
            TiradorNuevo = tirador;            
        }   
    }
}