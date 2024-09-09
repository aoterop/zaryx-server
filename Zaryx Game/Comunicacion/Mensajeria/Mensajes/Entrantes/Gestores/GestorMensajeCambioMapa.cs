using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeCambioMapa : IGestorMensaje
    {
        public Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_CambioMapa? me = Deserializador.Deserializar<ME_CambioMapa>(mensaje);

            if (sesion != null && me != null)
            {
                Mapa? nuevoMapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(me.NuevoMapa);

                if(nuevoMapa != null)
                {
                    IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);
                    
                    if(personaje != null)
                    {
                        GestorJuego.Instancia().GestorPersonajes.ActualizarPosicion(me.X, me.Y, sesion.IdSesion);
                        nuevoMapa.AgregarPersonaje(personaje);

                        if (me.UltimoMapa >= 0)
                        {
                            Mapa? ultimoMapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(me.UltimoMapa);
                            ultimoMapa?.EliminarPersonaje(personaje.IdSesion);
                        }
                    }                  
                }
            }
            return Task.CompletedTask;
        }
    }
}