using Zaryx_Game.Autenticacion;
using Zaryx_Game.Autenticacion.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;
using Zaryx_Mensajes.Entrantes;
using Zaryx_Mensajes.Procesamiento;
using Zaryx_Mensajes.Salientes.Mensajes;

namespace Zaryx_Game.Comunicacion.Mensajeria.Gestores
{
    internal class GestorMensajeLogin : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            string[] partes = mensaje.Split('§');
            ME_Login? m = Deserializador.Deserializar<ME_Login>(partes[0]);

            if (m != null && m.Usuario != null && m.HashContra != null)
            {
                CuentaDTO? cuenta = await Autenticador.Autenticar(m.Usuario, m.HashContra);

                if (cuenta == null)
                {// La cuenta no existe.
                    MS_Login ms = new((byte)Tipos.EstadoCuenta.NO_EXISTE);
                    Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    return;
                }

                if (cuenta.Password == "")
                {// Credenciales incorrectas.
                    MS_Login ms = new((byte)Tipos.EstadoCuenta.CREDENCIALES_INCORRECTAS);
                    Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    return;
                }

                if (cuenta.EstaBloqueada)
                {// Cuenta inactiva.
                    MS_Login ms = new((byte)Tipos.EstadoCuenta.INACTIVA);
                    Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    return;
                }

                if (cuenta.EstaBaneada)
                {// Cuenta baneada.
                    MS_Login ms = new((byte)Tipos.EstadoCuenta.BANEADA);
                    Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    return;
                }

                if (GestorDeCuentas.Instancia().EstaActiva(cuenta.IdCuenta))
                {// La cuenta ya está en uso.
                    MS_Login ms = new((byte)Tipos.EstadoCuenta.EN_USO);
                    Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    return;
                }

                // Si llega aquí, las credenciales son correctas (puede usar la cuenta).
                GestorDeCuentas.Instancia().AgregarCuenta(cuenta.IdCuenta);
                GestorDeSesiones.Instancia().ObtenerSesion(sesion.IdSesion)?.EstablecerCuenta(cuenta);

                MS_Login msl = new((byte)Tipos.EstadoCuenta.CREDENCIALES_CORRECTAS);
                Emisor.Enviar(sesion.IdSesion, msl.Tipo(), Serializador.Serializar(msl));
            }
        }
    }
}