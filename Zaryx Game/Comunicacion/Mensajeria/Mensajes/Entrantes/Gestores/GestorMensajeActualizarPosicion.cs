using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Estructuras;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeActualizarPosicion : IGestorMensaje
    {
        public Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_ActualizarPosicion? me = Deserializador.Deserializar<ME_ActualizarPosicion>(mensaje);

            if(me != null)
            {
                GestorJuego.Instancia().GestorPersonajes.ActualizarPosicion(me.X, me.Y, sesion.IdSesion);
            }             

            return Task.CompletedTask;
        }
    }
}