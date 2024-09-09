using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeCogerItem : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_CogerItem? me = Deserializador.Deserializar<ME_CogerItem>(mensaje);

            if(sesion != null && me != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if(personaje != null)
                {
                    Mapa? mapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(personaje.EntidadCombate.Mapa);

                    if(mapa != null)
                    {
                        if(mapa.ItemsSuelo.ContainsKey(me.IdItemSuelo))
                        {
                            ItemSuelo? item = mapa.ObtenerItemSuelo(me.IdItemSuelo);

                            if(item != null)
                            {
                                bool agregado;

                                if(personaje is Guerrero)
                                {
                                    agregado = await (personaje as Guerrero)!.Inventario.AgregarItem(item.IdItem, item.SeccionInventario, item.Cantidad, personaje.IdPersonaje, personaje.IdSesion);
                                }
                                else
                                {
                                    agregado = await (personaje as Tirador)!.Inventario.AgregarItem(item.IdItem, item.SeccionInventario, item.Cantidad, personaje.IdPersonaje, personaje.IdSesion);
                                }

                                if(agregado)
                                {
                                    mapa.QuitarItemSuelo(me.IdItemSuelo);
                                }
                            }
                        }
                    }
                }                
            }
        }
    }
}