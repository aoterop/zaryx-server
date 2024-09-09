using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Items.Guerrero;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeArrojarItem : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_ArrojarItem? me = Deserializador.Deserializar<ME_ArrojarItem>(mensaje);

            if (sesion != null && me != null)
            {
                IPersonaje? personaje = GestorJuego.Instancia().GestorPersonajes.ObtenerPersonaje(sesion.IdSesion);

                if (personaje != null)
                {
                    if (personaje is Guerrero)
                    {
                        ItemGuerrero? item = await (personaje as Guerrero)!.EliminarItem(me.SeccionInventario, me.Ranura);

                        Mapa? mapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(personaje.EntidadCombate.Mapa);

                        if (mapa != null)
                        {
                            mapa.AgregarItemSuelo(new ItemSuelo(item!.ReferenciaItem, me.SeccionInventario, item.Cantidad, personaje.EntidadCombate.X, personaje.EntidadCombate.Y));
                        }
                    }
                    else
                    {
                        ItemTirador? item = await (personaje as Tirador)!.EliminarItem(me.SeccionInventario, me.Ranura);
                                               

                        Mapa? mapa = GestorJuego.Instancia().GestorMapas.ObtenerMapa(personaje.EntidadCombate.Mapa);
                        

                        if(mapa != null)
                        {
                            mapa.AgregarItemSuelo(new ItemSuelo(item!.ReferenciaItem, me.SeccionInventario, item.Cantidad, personaje.EntidadCombate.X, personaje.EntidadCombate.Y));
                        }
                    }
                }
            }
        }
    }
}