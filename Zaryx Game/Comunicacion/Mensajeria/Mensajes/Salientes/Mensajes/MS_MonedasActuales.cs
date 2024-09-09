using Zaryx_Game.General;
using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes
{
    public class MS_MonedasActuales : IMensajeSaliente
    {
        public long MonedasActuales { get; set; }
        public byte Tipo() { return (byte)Tipos.MensajeSaliente.MS_MONEDAS_ACTUALES; }

        public MS_MonedasActuales(long monedasActuales)
        {
            MonedasActuales = monedasActuales;
        }
    }
}