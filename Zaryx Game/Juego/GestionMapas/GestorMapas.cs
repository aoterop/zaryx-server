using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Juego.Modelos.Chat;
using Zaryx_Game.Juego.Modelos.Mapas;

namespace Zaryx_Game.Juego.GestionMapas
{
    public class GestorMapas
    {
        private readonly ConcurrentDictionary<short, Mapa> Mapas;

        public GestorMapas()
        {
            Mapas = new ConcurrentDictionary<short, Mapa>();
        }

        public void EnviarMensajeGlboal(MensajeChat mensaje)
        {
            foreach (var mapa in Mapas.Values)
            {
                mapa.EnviarMensaje(mensaje);
            }
        }

        public Mapa? ObtenerMapa(short idMapa)
        {
            Mapas.TryGetValue(idMapa, out Mapa? mapa);
            return mapa;
        }

        public Mapa? ObtenerMapa(byte idSesion)
        {
            Mapa? m = null;
            foreach(var mapa in Mapas.Values)
            {
                if(mapa.Personajes.ContainsKey(idSesion))
                {
                    m = mapa;
                    break;
                }
            }

            return m;
        }

        public async Task CargarMapas()
        {
            short mapasCargados = 0;

            var mapas = await ObtenerMapas();
            var ficherosCeldas = LeerArchivos();

            foreach (var mapa in mapas)
            {
                if (!ficherosCeldas.ContainsKey(mapa.IdMapa)) continue;

                var celdas = CrearCeldas(ficherosCeldas, mapa.IdMapa);
                EstablecerCeldasNoCaminables(ficherosCeldas, mapa.IdMapa, celdas);

                var dimensiones = ObtenerDimensiones(ficherosCeldas, mapa.IdMapa);
                if(Mapas.TryAdd(mapa.IdMapa, new Mapa(mapa, celdas, dimensiones.Item1, dimensiones.Item2)))
                {
                    mapasCargados++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¡" + mapasCargados + " mapas cargados!");
        }


        private async Task<List<MapaDTO>> ObtenerMapas()
        {
            return await GestorDeDatos.Instancia().GestorMapa.ObtenerMapas();
        }

        private Dictionary<short, string[]> LeerArchivos()
        {
            var ficherosCeldas = new Dictionary<short, string[]>();
            var archivos = Directory.GetFiles(Path.Combine("..", "..", "..", "Juego", "GestionMapas", "Archivos"));

            foreach (var archivo in archivos)
            {
                var lineas = File.ReadAllLines(archivo);
                if (lineas.Length < 1) continue;

                ficherosCeldas.TryAdd(short.Parse(Path.GetFileNameWithoutExtension(archivo)), lineas);
            }

            return ficherosCeldas;
        }

        private Nodo[,] CrearCeldas(Dictionary<short, string[]> ficherosCeldas, short idMapa)
        {
            var dimensiones = ObtenerDimensiones(ficherosCeldas, idMapa);

            var celdas = new Nodo[dimensiones.Item1, dimensiones.Item2];

            for (short i = 0; i < dimensiones.Item1; i++)
            {
                for (short j = 0; j < dimensiones.Item2; j++)
                {
                    celdas[i, j] = new Nodo(i, j, true);
                }
            }

            return celdas;
        }

        private void EstablecerCeldasNoCaminables(Dictionary<short, string[]> ficherosCeldas, short idMapa, Nodo[,] celdas)
        {
            var regex = new Regex(@"\((\d+),\s*(\d+)\)");
            for (var i = 1; i < ficherosCeldas[idMapa].Length; i++)
            {
                var match = regex.Match(ficherosCeldas[idMapa][i]);
                if (match.Success)
                {
                    var x = int.Parse(match.Groups[1].Value);
                    var y = int.Parse(match.Groups[2].Value);
                    celdas[x, y].EsCaminable = false;
                }
            }
        }

        private (short, short) ObtenerDimensiones(Dictionary<short, string[]> ficherosCeldas, short idMapa)
        {
            var dimensiones = ficherosCeldas[idMapa][0].Split('x');
            var largo = short.Parse(dimensiones[0]);
            var ancho = short.Parse(dimensiones[1]);
            return (largo, ancho);
        }
    }
}