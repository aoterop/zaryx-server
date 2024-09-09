using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_InstanciaItemMapa : IMensajeSaliente
    {
        public long IdItemSuelo { get; set; }
        public short IdItem { get; set; }
        public int Cantidad { get; set; }
        public short X { get; set; }
        public short Y { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_INSTANCIA_ITEM_MAPA; }

        public MS_InstanciaItemMapa(long idItemSuelo, short idItem, int cantidad, short x, short y)
        {
            IdItemSuelo = idItemSuelo;
            IdItem = idItem;
            Cantidad = cantidad;
            X = x;
            Y = y;
        }
    }
}