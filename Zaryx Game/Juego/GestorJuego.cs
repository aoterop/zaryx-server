using Zaryx_Game.Juego.GestionMapas;
using Zaryx_Game.Juego.GestionPersonajes;
using Zaryx_Game.Juego.GestionPortales;
using Zaryx_Game.Juego.GestionItems;
using Zaryx_Game.Juego.GestionTiendas;

namespace Zaryx_Game.Juego
{
    public class GestorJuego
    {
        public static readonly GestorJuego _instancia = new();

        internal readonly GestorMapas GestorMapas;
        internal readonly GestorPersonajes GestorPersonajes;
        internal readonly GestorPortales GestorPortales;
        internal readonly GestorItems GestorItems;
        internal readonly GestorTiendas GestorTiendas;

        private GestorJuego()
        {
            GestorMapas = new GestorMapas();
            GestorPersonajes = new GestorPersonajes();
            GestorPortales = new GestorPortales();
            GestorItems = new GestorItems();
            GestorTiendas = new GestorTiendas();
        }

        public static GestorJuego Instancia() { return _instancia; }


        public async Task Inicializar()
        {
            await GestorMapas.CargarMapas();
            await GestorPortales.CargarPortales(); 
            await GestorItems.CargarItems();
            await GestorTiendas.CargarTiendas();
        }
    }
}