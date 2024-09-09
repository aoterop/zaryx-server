using System.Collections.Concurrent;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores;
using Zaryx_Game.General;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes
{
    internal class ManejadorDeMensajes
    {
        // Singleton.
        private static readonly ManejadorDeMensajes _instancia = new();
        private readonly ConcurrentDictionary<byte, IGestorMensaje> manejadorMensajes;

        private ManejadorDeMensajes()
        {
            manejadorMensajes = new ConcurrentDictionary<byte, IGestorMensaje>();
        }

        public static ManejadorDeMensajes Instancia { get { return _instancia; } }


        internal async Task ManejarMensaje(Sesion sesion, byte tipo, string mensaje)
        {
            await manejadorMensajes[tipo].GestionarMensaje(sesion, mensaje);
        }

        internal void RegistrarGestores()
        {// Todos son gestores para mensajes entrantes.
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_LOGIN, new GestorMensajeLogin());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_CREAR_PERSONAJE, new GestorMensajeCrearPersonaje());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_SOLICITAR_PERSONAJES, new GestorMensajeSolicitarPersonajes());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_BORRAR_PERSONAJE, new GestorMensajeBorrarPersonaje());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_PERSONAJE_ESCOGIDO, new GestorMensajePersonajeEscogido());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_CAMBIO_MAPA, new GestorMensajeCambioMapa());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_MOVIMIENTO_PERSONAJE, new GestorMensajeMovimientoPersonaje());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_ACTUALIZAR_POSICION, new GestorMensajeActualizarPosicion());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_INTERCAMBIO_SLOTS, new GestorMensajeIntercambioSlots());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_ARROJAR_ITEM, new GestorMensajeArrojarItem());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_COGER_ITEM, new GestorMensajeCogerItem());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_COMPRA_ITEM_TIENDA, new GestorMensajeCompraItemTienda());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_VENTA_ITEM_TIENDA, new GestorMensajeVentaItemTienda());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_MENSAJE_CHAT, new GestorMensajeMensajeChat());
            // METER MÁS...
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_CERRAR_PERSONAJE, new GestorMensajeCerrarPersonaje());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_LOG_OUT, new GestorMensajeLogOut());
            manejadorMensajes.TryAdd((byte)Tipos.MensajeEntrante.ME_CIERRE_SESION, new GestorMensajeCierreSesion());
        }
    }
}