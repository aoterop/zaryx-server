namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_IntercambioSlots
    {
        public byte SeccionInventario { get; set; }
        public byte RanuraOrigen { get; set; }
        public byte RanuraDestino { get; set; }
        public ME_IntercambioSlots() { }
    }
}