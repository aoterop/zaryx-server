using System.Collections.Concurrent;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Estructuras;
using Zaryx_Game.General;
using Zaryx_Game.Juego.GestionPersonajes;
using Zaryx_Game.Juego.Modelos.Chat;
using Zaryx_Game.Juego.Modelos.Entidades.Monstruos;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Portales;
using Zaryx_Game.Juego.Modelos.Tiendas;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Juego.Modelos.Mapas
{
    public class Mapa : IMapa
    {
        private long _siguienteIdItemSuelo;

        public short IdMapa { get; set; }
        public string NombreMapa { get; set; }
        public bool PermiteJcJ { get; set; }

        // Propiedades adicionales del mapa

        public readonly Nodo[,] Celdas;
        public short Ancho { get; set; } // X
        public short Largo { get; set; } // Y

        public ConcurrentDictionary<byte, IPersonaje> Personajes { get; set; }
        public ListaSegura<Portal> Portales { get; set; }
        public ListaSegura<Monstruo> Monstruos { get; set; }
        public ConcurrentDictionary<long, ItemSuelo> ItemsSuelo { get; set; }
        
        public ListaSegura<Tienda> Tiendas { get; set; }

        public Mapa(MapaDTO dto, Nodo[,] celdas, short ancho, short largo)
        {
            _siguienteIdItemSuelo = 0;

            IdMapa = dto.IdMapa;
            NombreMapa = dto.NombreMapa;
            PermiteJcJ = dto.PermiteJcJ;

            Personajes = new ConcurrentDictionary<byte, IPersonaje>();
            Portales = new ListaSegura<Portal>();
            Monstruos = new ListaSegura<Monstruo>();
            ItemsSuelo = new ConcurrentDictionary<long, ItemSuelo>();
            Tiendas = new ListaSegura<Tienda>();

            this.Celdas = celdas;
            Ancho = ancho;
            Largo = largo;
        }


        public void EnviarMensaje(MensajeChat mensaje)
        {
            MS_NuevoMensajeChat ms = new(mensaje);

            foreach (var p in Personajes.Values)
            {
                Emisor.Enviar(p.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
            }
        }

        public void AgregarItemSuelo(ItemSuelo item)
        {
            lock(ItemsSuelo)
            {                
                if (ItemsSuelo.TryAdd(_siguienteIdItemSuelo, new ItemSuelo(_siguienteIdItemSuelo, item.IdItem, item.SeccionInventario, item.Cantidad, item.X, item.Y)))
                {
                    MS_InstanciaItemMapa ms = new(_siguienteIdItemSuelo, item.IdItem, item.Cantidad, item.X, item.Y);                    

                    foreach (var p in Personajes.Values)
                    {
                        Emisor.Enviar(p.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    }

                    _siguienteIdItemSuelo++;
                }
            }
        }

        public void QuitarItemSuelo(long idItemSuelo)
        {
            lock(ItemsSuelo)
            {
                if(ItemsSuelo.ContainsKey(idItemSuelo))
                {
                    if (ItemsSuelo.TryRemove(idItemSuelo, out ItemSuelo? itemBorrado))
                    {
                        MS_EliminarItemMapa ms = new(idItemSuelo);

                        foreach(var p in Personajes.Values)
                        {
                            Emisor.Enviar(p.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                        }                       
                    }
                }              
            }
        }

        public ItemSuelo? ObtenerItemSuelo(long idItemSuelo)
        {
            ItemSuelo? item = new ItemSuelo();

            lock (ItemsSuelo)
            {
                if (ItemsSuelo.ContainsKey(idItemSuelo))
                {
                    item = ItemsSuelo[idItemSuelo];
                }
            }

            return item;
        }

        public void AgregarPersonaje(IPersonaje personaje)
        {
            if(!Personajes.ContainsKey(personaje.IdSesion))
            {
                if (Personajes.TryAdd(personaje.IdSesion, personaje))
                {// Si el personaje ha podido ser agregado exitosamente.
                    personaje.EntidadCombate.Mapa = IdMapa;

                    MS_PortalesMapa mpsm = new(Portales.ToList());
                    Emisor.Enviar(personaje.IdSesion, mpsm.Tipo(), Serializador.Serializar(mpsm));

                    foreach(var i in ItemsSuelo.Values)
                    {// Se le envían todos los items del suelo existentes al personaje.
                        MS_InstanciaItemMapa miim = new(i.IdItemSuelo, i.IdItem, i.Cantidad, i.X, i.Y);
                        Emisor.Enviar(personaje.IdSesion, miim.Tipo(), Serializador.Serializar(miim));
                    }

                    // Envío de las tiendas del mapa.
                    MS_EnviarTiendasMapa metm = new(Tiendas.ToList());
                    Emisor.Enviar(personaje.IdSesion, metm.Tipo(), Serializador.Serializar(metm));

                    MS_EntradaNuevoPersonajeMapa ms = new(null, null);

                    switch(personaje.Clase())
                    {
                        case (byte)Tipos.Clase.GUERRERO: { ms.GuerreroNuevo = (Guerrero)personaje; } break;
                        case (byte)Tipos.Clase.TIRADOR: { ms.TiradorNuevo = (Tirador)personaje; } break;

                        default: { }  break;
                    }

                    MS_PersonajeMapa mpm = new(null!, null!, null!);

                    foreach (var p in Personajes.Values)
                    {
                        if (p.IdSesion != personaje.IdSesion)
                        {
                            switch(p.Clase())
                            {
                                case (byte)Tipos.Clase.GUERRERO:
                                    {
                                        mpm.GuerreroMapa = (Guerrero)p;
                                        mpm.Nodos = mpm.GuerreroMapa.EntidadCombate.NodosPorRecorrer.ToList();
                                      
                                        mpm.TiradorMapa = null!;
                                    }break;

                                case (byte)Tipos.Clase.TIRADOR:
                                    {
                                        mpm.TiradorMapa = (Tirador)p;
                                        mpm.Nodos = mpm.TiradorMapa.EntidadCombate.NodosPorRecorrer.ToList();
        
                                        mpm.GuerreroMapa = null!;
                                    }
                                    break;

                                case (byte)Tipos.Clase.MAGO:
                                    {

                                    }break;

                                default: { } break;
                            }

                            Emisor.Enviar(p.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                            Emisor.Enviar(personaje.IdSesion, mpm.Tipo(), Serializador.Serializar(mpm));
                        }
                    }                  
                }
            }
        }

        public void EliminarPersonaje(byte idSesion)
        {
            if(Personajes.ContainsKey(idSesion))
            {
                if(Personajes.Remove(idSesion, out IPersonaje? p))
                {
                    MS_SalidaPersonaje ms = new(p.IdPersonaje);
                    foreach (byte sesion in Personajes.Keys)
                    {
                        if (sesion != idSesion)
                        {
                            Emisor.Enviar(sesion, ms.Tipo(), Serializador.Serializar(ms));
                        }
                    }
                }
            }
        }
   
        public void MoverPersonaje(IPersonaje personaje, List<Nodo> nodos)
        {
            if(Personajes.ContainsKey(personaje.IdSesion))
            {
                MS_MovimientoPersonaje ms = new(nodos, personaje.IdPersonaje);
                string mensaje = Serializador.Serializar(ms);

                foreach (byte sesion in Personajes.Keys)
                {
                    if (sesion != personaje.IdSesion)
                    {
                        Emisor.Enviar(sesion, ms.Tipo(), mensaje);
                    }
                }
            }
        }   
    }
}