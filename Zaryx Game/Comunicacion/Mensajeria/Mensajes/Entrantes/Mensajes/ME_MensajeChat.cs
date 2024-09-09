namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_MensajeChat
    {
        public byte TipoMensaje { get; set; }
        public string? Texto { get; set; }
        public string? Receptor { get; set; }
        public ME_MensajeChat() { }
    }
}