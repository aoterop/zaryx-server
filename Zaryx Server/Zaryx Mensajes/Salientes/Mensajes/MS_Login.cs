using Zaryx_Mensajes.Salientes.Interfaces;

namespace Zaryx_Mensajes.Salientes.Mensajes
{
    public class MS_Login : IMensajeSaliente
    {
        public byte EstadoCuenta { get; set; }

        public byte Tipo() { return (byte)Tipos.MensajeSaliente.LOGIN; }

        public MS_Login(byte estadoCuenta)
        {
            EstadoCuenta = estadoCuenta;
        }        
    }
}