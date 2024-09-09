using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_AumentoCantidadItemInventario : IMensajeSaliente
    {
        public short CantidadAumentadad { get; set; }
        public byte SeccionInventario { get; set; }
        public byte Ranura { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_AUMENTO_CANTIDAD_ITEM_INVENTARIO; }

        public MS_AumentoCantidadItemInventario(short cantidad, byte seccionInventario, byte ranura)
        {
            CantidadAumentadad = cantidad;
            SeccionInventario = seccionInventario;
            Ranura = ranura;
        }
    }
}