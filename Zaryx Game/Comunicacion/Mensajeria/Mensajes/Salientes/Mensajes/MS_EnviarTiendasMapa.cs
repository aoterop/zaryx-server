using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Tiendas;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_EnviarTiendasMapa : IMensajeSaliente
    {
        public List<Tienda> TiendasMapa { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_TIENDAS_MAPA; }

        public MS_EnviarTiendasMapa(List<Tienda> tiendasMapa)
        {
            TiendasMapa = tiendasMapa;
        }
    }
}