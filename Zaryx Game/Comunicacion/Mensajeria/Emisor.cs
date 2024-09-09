namespace Zaryx_Game.Comunicacion.Conexion
{
    internal static class Emisor
    {
        public static void Enviar(byte idSesion, byte tipoMensaje, string mensaje)
        {
            Conector.Instancia.EnviarMensaje(idSesion.ToString() + "§" + tipoMensaje.ToString() + "§" + mensaje);
        }
    }
}