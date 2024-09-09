using Zaryx_Game.Autenticacion.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Juego;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeCerrarPersonaje : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            if (sesion != null)
            {
                if (sesion.Cuenta != null)
                {
                    GestorJuego.Instancia().GestorMapas.ObtenerMapa(sesion.IdSesion)?.EliminarPersonaje(sesion.IdSesion);
                    await GestorJuego.Instancia().GestorPersonajes.GuardarDatosPersonaje(sesion.IdSesion);
                }
            }
        }
    }
}