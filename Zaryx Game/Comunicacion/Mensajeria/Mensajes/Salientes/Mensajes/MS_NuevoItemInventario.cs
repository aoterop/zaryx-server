using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_NuevoItemInventario : IMensajeSaliente
    {
        public short Cantidad { get; set; }
        public short IdItem { get; set; }
        public byte SeccionInventario { get; set; }
        public byte Ranura { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_NUEVO_ITEM_INVENTARIO; }

        public MS_NuevoItemInventario(short cantidad, short idItem, byte seccionInventario, byte ranura)
        {
            Cantidad = cantidad;
            IdItem = idItem;
            SeccionInventario = seccionInventario;
            Ranura = ranura;
        }
    }
}