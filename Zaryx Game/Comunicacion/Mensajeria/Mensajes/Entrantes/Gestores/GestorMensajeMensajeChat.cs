using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.General;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Chat;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeMensajeChat : IGestorMensaje
    {
        public Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_MensajeChat? me = Deserializador.Deserializar<ME_MensajeChat>(mensaje);

            if(sesion != null && me != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if (personaje != null)
                {
                    MensajeChat m = new(me.Texto, personaje.IdPersonaje, personaje.EntidadCombate.Nombre, me.TipoMensaje);
                    
                    switch (me.TipoMensaje)
                    {
                        case (byte)Tipos.MensajeChat.NORMAL:
                            {
                                Mapa? mapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(sesion.IdSesion);
                                mapa?.EnviarMensaje(m);
                            }
                            break;

                        case (byte)Tipos.MensajeChat.GLOBAL:
                            {
                                Mapa? mapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(sesion.IdSesion);

                                if(mapa != null)
                                {
                                    m.Mapa = mapa.NombreMapa;
                                    GestorJuego.Instancia().GestorMapas.EnviarMensajeGlboal(m);
                                }
                            }
                            break;

                        case (byte)Tipos.MensajeChat.PRIVADO:
                            {
                                if(me.Receptor != null && me.Receptor.Trim().Length > 0)
                                {
                                    IPersonaje? receptor = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(me.Receptor);
                                    
                                    if(receptor != null)
                                    {
                                        MS_NuevoMensajeChat ms = new(m);
                                        Emisor.Enviar(receptor.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                                    }
                                }
                            }
                            break;

                        default: { } break;
                    }
                }              
            }

            return Task.CompletedTask;
        }
    }
}