namespace Zaryx_Mensajes
{
    public static class Tipos
    {
        public enum MensajeEntrante : byte
        {
            LOGIN = 0,
            CREAR_PERSONAJE = 1,
            SOLICITAR_PERSONAJES = 2,
            CIERRE_SESION = 255
        }

        public enum MensajeSaliente : byte
        {
            LOGIN = 0,
            CREAR_PERSONAJE = 1,
            ENVIAR_PERSONAJES = 2,
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
    }
}