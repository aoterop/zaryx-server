namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes
{
    public class ME_CambioMapa
    {
        public long IdPersonaje { get; set; }
        public short UltimoMapa { get; set; }
        public short NuevoMapa { get; set; }
        public short X { get; set; }
        public short Y { get; set; }
        public ME_CambioMapa() { }
    }
}