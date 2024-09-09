namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_BorrarPersonaje
    {
        public long IdPersonaje { get; set; }
        public byte Clase { get; set; }
        public ME_BorrarPersonaje() { }
    }
}