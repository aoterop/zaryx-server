using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Guerrero;

namespace Zaryx_Game.Juego.Modelos.Entidades.Personajes
{
    public interface IPersonaje
    {
        byte IdSesion { get; set; }
        long IdPersonaje { get; set; }
        long CuentaAsociada { get; set; }
        byte Peinado { get; set; }
        byte AspectoFacial { get; set; }
        bool EsAdmin { get; set; }
        int TiempoJugado { get; set; }
        long Monedas { get; set; }
        bool EstaSilenciado { get; set; }        
        IEntidadCombate EntidadCombate { get; set; }
        DateTime MomentoInicio { get; set; }
        Task<bool> GuardarDatos();
        byte Clase();
    }
}