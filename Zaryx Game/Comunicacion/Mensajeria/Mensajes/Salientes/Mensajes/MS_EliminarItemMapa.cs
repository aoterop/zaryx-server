using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_EliminarItemMapa : IMensajeSaliente
    {
        public long IdItemSuelo { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_ELIMINAR_ITEM_MAPA; }

        public MS_EliminarItemMapa(long idItemSuelo)
        {
            IdItemSuelo = idItemSuelo;
        }
    }
}