using System.Collections.Concurrent;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Datos;
using Zaryx_Game.Juego.Modelos.Mapas;
using Zaryx_Game.Juego.Modelos.Portales;
using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Juego.GestionPortales
{
    public class GestorPortales
    {
        private readonly ConcurrentDictionary<int, Portal> Portales;

        public GestorPortales()
        {
            Portales = new ConcurrentDictionary<int, Portal>();
        }

        public async Task CargarPortales()
        {
            List<PortalDTO> portales = await ObtenerPortales();


            int portalesCargados = 0;

            foreach(var portal in portales)
            {
                Portal p = new Portal(portal);

                if(Portales.TryAdd(portal.IdPortal, p))
                {
                    GestorJuego.Instancia().GestorMapas.ObtenerMapa(portal.MapaOrigen)?.Portales.Add(p);
                    portalesCargados++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¡" + portalesCargados + " portales cargados!");
        }

        public Portal? ObtenerPortal(int idPortal)
        {
            Portales.TryGetValue(idPortal, out Portal? portal);
            return portal;
        }

        private async Task<List<PortalDTO>> ObtenerPortales()
        {
            return await GestorDeDatos.Instancia().GestorPortal.ObtenerTodosLosPortales();
        }
    }
}