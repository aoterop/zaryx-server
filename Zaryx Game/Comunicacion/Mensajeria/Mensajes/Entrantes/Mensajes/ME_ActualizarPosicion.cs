namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_ActualizarPosicion
    {
        public short X { get; set; }
        public short Y { get; set; }
        public long IdPersonaje { get; set; }

        public ME_ActualizarPosicion() { }
    }
}