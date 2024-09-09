namespace Zaryx_Game.Juego.Modelos.Chat
{
    public class MensajeChat
    {
        public string? Texto { get; set; }
        public long PersonajeEmisor { get; set; }
        public string? NombreEmisor { get; set; }
        public byte Tipo { get; set; }
        public string? Mapa { get; set; }

        public MensajeChat(string? texto, long personajeEmisor, string? nombreEmisor, byte tipo)
        {
            Texto = texto;
            PersonajeEmisor = personajeEmisor;
            NombreEmisor = nombreEmisor;
            Tipo = tipo;
        }

        public MensajeChat Clone()
        {
            return new MensajeChat
            {
                Texto = Texto,
                NombreEmisor = NombreEmisor,
                PersonajeEmisor = PersonajeEmisor,
                Tipo = Tipo
            };
        }

        public MensajeChat() { }
    }
 }