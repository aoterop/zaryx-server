using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.General;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeIntercambioSlots : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_IntercambioSlots? me = Deserializador.Deserializar<ME_IntercambioSlots>(mensaje);

            if(sesion != null && me != null)
            {
                Console.WriteLine("Se quiere cambiar del slot: " + me.RanuraOrigen + " al slot: " + me.RanuraDestino + " de la sección: " + me.SeccionInventario);
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if(personaje != null)
                {
                    if(personaje.Clase() == (byte)Tipos.Clase.GUERRERO)
                    {// Guerrero.
                        switch(me.SeccionInventario)
                        {
                            case (byte)Tipos.SeccionesInventario.CONSUMO:
                                {
                                    await (personaje as Guerrero)!.Inventario.IntercambiarItemsConsumo(me.RanuraOrigen, me.RanuraDestino);
                                }break;

                            case (byte)Tipos.SeccionesInventario.EQUIPO:
                                {
                                    await (personaje as Guerrero)!.Inventario.IntercambiarItemsEquipo(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;

                            case (byte)Tipos.SeccionesInventario.MAESTRIA:
                                {
                                    await (personaje as Guerrero)!.Inventario.IntercambiarMaestrias(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;

                            case (byte)Tipos.SeccionesInventario.MISCELANEA:
                                {
                                    await (personaje as Guerrero)!.Inventario.IntercambiarMiscelanea(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;
                        }
                    }
                    else
                    {// Tirador.
                        switch (me.SeccionInventario)
                        {
                            case (byte)Tipos.SeccionesInventario.CONSUMO:
                                {
                                    await (personaje as Tirador)!.Inventario.IntercambiarItemsConsumo(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;

                            case (byte)Tipos.SeccionesInventario.EQUIPO:
                                {
                                    await (personaje as Tirador)!.Inventario.IntercambiarItemsEquipo(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;

                            case (byte)Tipos.SeccionesInventario.MAESTRIA:
                                {
                                    await (personaje as Tirador)!.Inventario.IntercambiarMaestrias(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;

                            case (byte)Tipos.SeccionesInventario.MISCELANEA:
                                {
                                    await (personaje as Tirador)!.Inventario.IntercambiarMiscelanea(me.RanuraOrigen, me.RanuraDestino);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}