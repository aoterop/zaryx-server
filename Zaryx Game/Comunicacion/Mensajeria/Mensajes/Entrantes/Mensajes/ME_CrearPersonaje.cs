namespace Zaryx_Mensajes.Entrantes
{
    public class ME_CrearPersonaje
    {
        public string? Nombre { get; set; }
        public byte Clase { get; set; }
        public byte Peinado { get; set; }
        public byte AspectoFacial { get; set; }

        public ME_CrearPersonaje() { }
    }
}