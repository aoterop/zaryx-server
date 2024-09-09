using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Estructuras;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeMovimientoPersonaje : IGestorMensaje
    {
        public Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_MovimientoPersonaje? me = Deserializador.Deserializar<ME_MovimientoPersonaje>(mensaje);

            if(sesion != null && me != null && me.Nodos != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);
                
                if(personaje != null)
                {
                    personaje.EntidadCombate.NodosPorRecorrer = new ListaSegura<Nodo>(me.Nodos);
                    GestorJuego.Instancia().GestorMapas.ObtenerMapa(me.IdMapa)?.MoverPersonaje(personaje, me.Nodos);
                }
            }

            return Task.CompletedTask;
        }
    }
}