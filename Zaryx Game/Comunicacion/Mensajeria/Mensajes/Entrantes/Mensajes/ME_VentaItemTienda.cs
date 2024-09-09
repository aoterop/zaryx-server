namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_VentaItemTienda
    {
        public int IdTienda { get; set; }
        public short IdItemAVender { get; set; }
        public byte Ranura { get; set; }
        public short Cantidad { get; set; }

        public ME_VentaItemTienda() { }
    }
}