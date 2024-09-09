using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Tiendas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeVentaItemTienda : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_VentaItemTienda? me = Deserializador.Deserializar<ME_VentaItemTienda>(mensaje);

            if(sesion != null && me != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if(personaje != null)
                {
                    Tienda? tienda = GestorJuego.Instancia().GestorTiendas.ObtenerTienda(me.IdTienda);
                    Tuple<byte, Item>? item = GestorJuego.Instancia().GestorItems.ObtenerItem(me.IdItemAVender);

                    if(tienda != null && item != null && item.Item2 != null)
                    {
                        long monedasGanadas = (tienda.RatioCompra * me.Cantidad * item.Item2.Precio) / (100);

                        personaje.Monedas += monedasGanadas;

                        if (personaje is Guerrero)
                        {
                            (personaje as Guerrero)!.Inventario.EliminarItem(item.Item1, me.Ranura);
                        }
                        else if (personaje is Tirador)
                        {
                            (personaje as Tirador)!.Inventario.EliminarItem(item.Item1, me.Ranura);
                        }

                        MS_MonedasActuales ms = new(personaje.Monedas);
                        Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    }
                }
            }

            await Task.CompletedTask;
        }
    }
}