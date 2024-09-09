using System.Collections.Concurrent;
using Zaryx_Game.Datos;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Portales;

namespace Zaryx_Game.Juego.GestionPersonajes
{
    public class GestorPersonajes
    {
        private readonly ConcurrentDictionary<byte, IPersonaje> Personajes;

        public GestorPersonajes()
        {
            Personajes = new ConcurrentDictionary<byte, IPersonaje>();
        }

        public IPersonaje? ObtenerPersonaje(byte idSesion)
        {
            Personajes.TryGetValue(idSesion, out IPersonaje? personaje);
            return personaje;
        }

        public IPersonaje? ObtenerPersonaje(string nombre)
        {
            IPersonaje? personaje = null;

            foreach(var p in Personajes.Values)
            {
                if (p.EntidadCombate.Nombre == nombre)
                {
                    personaje = p;
                    break;
                }
            }

            return personaje;
        }

        public bool AgregarPersonaje(IPersonaje personaje)
        {
            if (!Personajes.ContainsKey(personaje.IdSesion))
            {
                return Personajes.TryAdd(personaje.IdSesion, personaje);
            }
            else { return false; }
        }

        public bool EliminarPersonaje(byte idSesion)
        {
            if (Personajes.ContainsKey(idSesion))
            {
                return Personajes.TryRemove(idSesion, out _);
            }
            else { return true; }
        }

        public void ActualizarPosicion(short x, short y, byte idSesion)
        {
            if(Personajes.ContainsKey(idSesion))
            {
                Personajes[idSesion].EntidadCombate.X = x;
                Personajes[idSesion].EntidadCombate.Y = y;

                Personajes[idSesion].EntidadCombate.NodosPorRecorrer.RemoveAt(0);           
            }
        }

        public async Task GuardarDatosPersonaje(byte idSesion)
        {
            Personajes.TryRemove(idSesion, out IPersonaje? personaje);

            if (personaje != null)
            {
                Console.WriteLine("Se ha eliminado al personaje");
                await personaje.GuardarDatos();
            }
        }
    }
}