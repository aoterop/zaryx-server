using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Autenticacion
{
    internal static class Autenticador
    {
        /// <summary>
        /// Permite autenticar un nombre de cuenta y contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de la cuenta.</param>
        /// <param name="password">Contraseña de la cuenta.</param>
        /// <returns>Cuenta de la base de datos que coincide con el nombre y contraseña.</returns>
        public static async Task<CuentaDTO?> Autenticar(string nombre, string hashContra)
        {
            if(nombre != null && hashContra != null)
            {
                CuentaDTO? cuenta = await GestorDeDatos.Instancia().GestorCuenta.ObtenerCuentaPorNombre(nombre);

                if(cuenta != null)
                {// Se comprueba el hash de la bd con el que ha enviado el cliente.

                    if (cuenta.Password!.ToUpper() == hashContra)
                    {// Credenciales correctas.
                        return cuenta;
                    }
                    else
                    {// Credenciales incorrectas.

                        cuenta.Email = "";
                        cuenta.Password = "";
                        return cuenta;
                    }
                }
            }           
            return null;           
        }

        public static async Task<bool> CrearPersonaje(long cuentaAsociada, string nombre, byte clase, byte peinado, byte aspectoFacial)
        {
            bool creado = false;

            switch(clase)
            {
                case (byte)Tipos.Clase.GUERRERO:
                    {
                        creado = await GestorDeDatos.Instancia().GestorGuerrero.CrearGuerrero(cuentaAsociada, nombre, peinado, aspectoFacial);
                    }
                    break;

                case (byte)Tipos.Clase.TIRADOR:
                    {
                        creado = await GestorDeDatos.Instancia().GestorTirador.CrearTirador(cuentaAsociada, nombre, peinado, aspectoFacial);
                    }
                    break;

                case (byte)Tipos.Clase.MAGO:
                    {// En el futuro...

                    }
                    break;
            }

            return creado;
        }
    }
}