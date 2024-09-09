using Zaryx_Game.Autenticacion.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Juego;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeLogOut : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            if(sesion != null)
            {
                if (sesion.Cuenta != null)
                {
                    GestorDeCuentas.Instancia().EliminarCuenta(sesion.Cuenta.IdCuenta);
                    GestorJuego.Instancia().GestorMapas.ObtenerMapa(sesion.IdSesion)?.EliminarPersonaje(sesion.IdSesion);
                    await GestorJuego.Instancia().GestorPersonajes.GuardarDatosPersonaje(sesion.IdSesion);
                }
            }
        }
    }
}