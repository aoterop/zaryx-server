using System.Collections.Concurrent;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Juego.Modelos.Tiendas;

namespace Zaryx_Game.Juego.GestionTiendas
{
    public class GestorTiendas
    {
        private ConcurrentDictionary<int, Tienda> Tiendas { get; set; }

        public GestorTiendas()
        {
            Tiendas = new ConcurrentDictionary<int, Tienda>();
        }

        public Tienda? ObtenerTienda(int idTienda)
        {
            Tiendas.TryGetValue(idTienda, out Tienda? tienda);
            return tienda;
        }



        public async Task CargarTiendas()
        {
            int tiendasCargadas = 0;
            int itemsDeTiendas = 0;

            List<TiendaDTO> tiendasDTO = await GestorDeDatos.Instancia().GestorTienda.ObtenerTodasLasTiendas();

            foreach(var tienda in tiendasDTO)
            {
                List<ItemTiendaDTO> itemsTienda = await GestorDeDatos.Instancia().GestorItemTienda.ObtenerTodosLosItemsDeUnaTienda(tienda.IdTienda);

                Tienda t = new(tienda);

                foreach(var itemTienda in itemsTienda)
                {
                    t.ItemsTienda.Add(new ItemTienda(itemTienda));
                }

                if(Tiendas.TryAdd(tienda.IdTienda, t))
                {
                    GestorJuego.Instancia().GestorMapas.ObtenerMapa(t.MapaTienda)?.Tiendas.Add(t);
                    itemsDeTiendas += t.ItemsTienda.Count;
                    tiendasCargadas++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¡" + tiendasCargadas + " tiendas cargadas!");
            Console.WriteLine("¡" + itemsDeTiendas + " items de tiendas cargados!");
        }
    }
}