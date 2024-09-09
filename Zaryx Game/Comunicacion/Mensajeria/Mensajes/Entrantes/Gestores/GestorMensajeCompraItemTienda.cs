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
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeCompraItemTienda : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_CompraItemTienda? me = Deserializador.Deserializar<ME_CompraItemTienda>(mensaje);

            if(sesion != null && me != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if(personaje != null)
                {
                    Tuple<byte, Item>? itemAComprar = GestorJuego.Instancia().GestorItems.ObtenerItem(me.ItemOfertado);

                    if(itemAComprar != null)
                    {
                        long precioTotal = itemAComprar.Item2.Precio * me.Cantidad;

                        if(precioTotal <= personaje.Monedas)
                        {// Se lo puede permitir.

                            bool agregado = false;

                            if(personaje is Guerrero)
                            {
                                agregado = await (personaje as Guerrero)!.Inventario.AgregarItem(itemAComprar.Item2.IdItem, itemAComprar.Item1, me.Cantidad, personaje.IdPersonaje, personaje.IdSesion);
                            }
                            else if(personaje is Tirador)
                            {
                                agregado = await (personaje as Tirador)!.Inventario.AgregarItem(itemAComprar.Item2.IdItem, itemAComprar.Item1, me.Cantidad, personaje.IdPersonaje, personaje.IdSesion);
                            }
                            
                            if(agregado)
                            {
                                Console.WriteLine("Transacción completada con éxito");
                                personaje.Monedas -= precioTotal;
                                MS_MonedasActuales ms = new(personaje.Monedas);
                                Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                            }
                            else { Console.WriteLine("No se pudo realizar la transacción"); }
                        } 
                        else { Console.WriteLine("No le alcanza el dinero"); }
                    }
                }
            }
        }
    }
}