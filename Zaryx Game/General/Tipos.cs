namespace Zaryx_Game.General
{
    public static class Tipos
    {
        public enum MensajeEntrante : byte
        {
            ME_LOGIN = 0,
            ME_CREAR_PERSONAJE = 1,
            ME_SOLICITAR_PERSONAJES = 2,
            ME_BORRAR_PERSONAJE = 3,
            ME_PERSONAJE_ESCOGIDO = 4,
            ME_CAMBIO_MAPA = 5,
            ME_MOVIMIENTO_PERSONAJE = 6,
            ME_ACTUALIZAR_POSICION = 7,
            ME_INTERCAMBIO_SLOTS = 8,
            ME_ARROJAR_ITEM = 9,
            ME_COGER_ITEM = 10,
            ME_COMPRA_ITEM_TIENDA = 11,
            ME_VENTA_ITEM_TIENDA = 12,
            ME_MENSAJE_CHAT = 13,

            ME_REGISTRAR_SESION = 252,
            ME_CERRAR_PERSONAJE = 253,
            ME_LOG_OUT = 254,
            ME_CIERRE_SESION = 255
        }

        public enum MensajeSaliente : byte
        {
            MS_LOGIN = 0,
            MS_CREAR_PERSONAJE = 1,
            MS_ENVIAR_PERSONAJES = 2,
            MS_PERSONAJE_BORRADO = 3,
            MS_NUEVO_PERSONAJE_MAPA = 4,
            MS_PERSONAJES_MAPA = 5, 
            MS_SALIDA_PERSONAJE = 6,
            MS_MOVIMIENTO_PERSONAJE = 7,
            MS_PORTALES_MAPA = 8,
            MS_INSTANCIA_ITEM_MAPA = 9,
            MS_ELIMINAR_ITEM_MAPA = 10,
            MS_NUEVO_ITEM_INVENTARIO = 11,
            MS_AUMENTO_CANTIDAD_ITEM_INVENTARIO = 12,
            MS_TIENDAS_MAPA = 13,
            MS_MONEDAS_ACTUALES = 14,
            MS_NUEVO_MENSAJE_CHAT = 15,

        }

        public enum Clase : byte
        {
            GUERRERO = 0,
            TIRADOR = 1,
            MAGO = 2
        }

        public enum EstadoCuenta : byte
        {
            NO_EXISTE,
            CREDENCIALES_INCORRECTAS,
            CREDENCIALES_CORRECTAS,
            INACTIVA,
            BANEADA,
            EN_USO
        }

        public enum Items : byte
        {
            CONSUMO,
            EQUIPO_DEFENSIVO,
            EQUIPO_OFENSIVO,
            MAESTRIA_GUERRERO,
            MAESTRIA_TIRADOR,
            MISCELANEA,
            NO_ESPECIFICADO = 255
        }

        public enum SeccionesInventario : byte
        {
            CONSUMO,
            EQUIPO,
            MAESTRIA,
            MISCELANEA
        }

        public enum MensajeChat : byte
        {
            NORMAL,
            GLOBAL,
            PRIVADO,
            GRUPAL
        }
    }
}