using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Mensajes.Salientes.Mensajes
{
    public class MS_EnviarPersonajes : IMensajeSaliente
    {
        public List<Guerrero> Guerreros { get; set; }
        public List<Tirador> Tiradores { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_ENVIAR_PERSONAJES; }

        public MS_EnviarPersonajes(List<Guerrero> guerreros, List<Tirador> tiradores)
        {
            Guerreros = guerreros;
            Tiradores = tiradores;
        }
    }
}