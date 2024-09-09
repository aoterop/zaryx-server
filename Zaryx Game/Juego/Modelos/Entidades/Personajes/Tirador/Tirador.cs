using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador
{
    public class Tirador : IPersonaje
    {
        public byte IdSesion { get; set; }
        public long IdPersonaje { get; set; }
        public long CuentaAsociada { get; set; }
        public byte Peinado { get; set; }
        public byte AspectoFacial { get; set; }
        public bool EsAdmin { get; set; }
        public int TiempoJugado { get; set; }
        public long Monedas { get; set; }
        public bool EstaSilenciado { get; set; }
        public IEntidadCombate EntidadCombate { get; set; }
        public DateTime MomentoInicio { get; set; }
        public InventarioTirador Inventario { get; set; }

        public Tirador(TiradorDTO dto, byte idSesion)
        {
            MomentoInicio = DateTime.Now;

            IdSesion = idSesion;
            IdPersonaje = dto.IdPersonaje;
            CuentaAsociada = dto.CuentaAsociada;
            Peinado = dto.Peinado;
            AspectoFacial = dto.AspectoFacial;
            EsAdmin = dto.EsAdmin;
            TiempoJugado = dto.TiempoJugado;
            Monedas = dto.Monedas;
            EstaSilenciado = dto.EstaSilenciado;

            EntidadCombate = new GuerreroEntidadCombate(IdSesion, dto.NombrePersonaje, dto.UltimoHp, dto.UltimoMp, dto.UltimoMapa, dto.UltimoMapaX, dto.UltimoMapaY, dto.NivelPersonaje, dto.ExperienciaPersonaje);

            Inventario = new InventarioTirador();
        }

        public async Task CargarInventario()
        {
            List<ItemTiradorDTO> items = await GestorDeDatos.Instancia().GestorItemTirador.ObtenerTodosLosItemsDeUnTirador(IdPersonaje);

            foreach (var item in items)
            {
                switch (GestorJuego.Instancia().GestorItems.ObtenerItem(item.ReferenciaItem)?.Item2.Tipo())
                {
                    case (byte)Tipos.Items.CONSUMO:
                        {
                            Inventario.ItemsConsumo.Add(item.RanuraInventario, new ItemTirador(item));
                        }
                        break;

                    case (byte)Tipos.Items.EQUIPO_DEFENSIVO:
                    case (byte)Tipos.Items.EQUIPO_OFENSIVO:
                        {
                            Inventario.ItemsEquipo.Add(item.RanuraInventario, new ItemTirador(item));
                        }
                        break;

                    case (byte)Tipos.Items.MAESTRIA_GUERRERO:
                    case (byte)Tipos.Items.MAESTRIA_TIRADOR:
                        {
                            Inventario.Maestrias.Add(item.RanuraInventario, new ItemTirador(item));
                        }
                        break;


                    case (byte)Tipos.Items.MISCELANEA:
                        {
                            Inventario.Miscelanea.Add(item.RanuraInventario, new ItemTirador(item));
                        }
                        break;

                    default: { } break;
                }
            }
        }
            
        public async Task<ItemTirador?> EliminarItem(byte seccion, byte ranura)
        {
            ItemTirador? item = null;
            switch (seccion)
            {
                case (byte)Tipos.SeccionesInventario.CONSUMO:
                    {
                        if (Inventario.ItemsConsumo.ContainsKey(ranura))
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(Inventario.ItemsConsumo[ranura]!.IdItemTirador);
                            if (result) 
                            {
                                item = Inventario.ItemsConsumo[ranura].Clone();
                                Inventario.EliminarItemConsumo(ranura); 
                            }
                        }
                    }
                    break;

                case (byte)Tipos.SeccionesInventario.EQUIPO:
                    {
                        if (Inventario.ItemsEquipo.ContainsKey(ranura))
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(Inventario.ItemsEquipo[ranura]!.IdItemTirador);
                            if (result) 
                            {
                                item = Inventario.ItemsEquipo[ranura].Clone();
                                Inventario.EliminarItemEquipo(ranura); 
                            }
                        }
                    }
                    break;

                case (byte)Tipos.SeccionesInventario.MAESTRIA:
                    {
                        if (Inventario.Maestrias.ContainsKey(ranura))
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(Inventario.Maestrias[ranura]!.IdItemTirador);
                            if (result)
                            {
                                item = Inventario.Maestrias[ranura].Clone();
                                Inventario.EliminarItemMaestria(ranura);
                            }
                        }
                    }
                    break;

                case (byte)Tipos.SeccionesInventario.MISCELANEA:
                    {
                        if (Inventario.Miscelanea.ContainsKey(ranura))
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(Inventario.Miscelanea[ranura]!.IdItemTirador);
                            if (result) 
                            {
                                item = Inventario.Miscelanea[ranura].Clone();
                                Inventario.EliminarItemMiscelanea(ranura); 
                            }
                        }
                    }
                    break;

                default: { } break;
            }
            return item;
        }

        public async Task<bool> GuardarDatos()
        {
            ITirador tirador = GestorDeDatos.Instancia().GestorTirador.CrearTirador();

            tirador.IdPersonaje = IdPersonaje;
            tirador.NivelPersonaje = EntidadCombate.Nivel;
            tirador.CuentaAsociada = CuentaAsociada;
            tirador.NombrePersonaje = EntidadCombate.Nombre!;
            tirador.Peinado = Peinado;
            tirador.AspectoFacial = AspectoFacial;
            tirador.EsAdmin = EsAdmin;
            tirador.TiempoJugado = TiempoJugado + (int)(DateTime.Now - MomentoInicio).TotalSeconds;
            tirador.UltimoHp = EntidadCombate.Hp;
            tirador.UltimoMp = EntidadCombate.Mp;
            tirador.Monedas = Monedas;
            tirador.NivelPersonaje = EntidadCombate.Nivel;
            tirador.UltimoMapa = EntidadCombate.Mapa;
            tirador.UltimoMapaX = EntidadCombate.X;
            tirador.UltimoMapaY = EntidadCombate.Y;
            tirador.ExperienciaPersonaje = EntidadCombate.Experiencia;
            tirador.EstaSilenciado = EstaSilenciado;

            EntidadCombate.NodosPorRecorrer.Dispose();

            await GuardarInventario();

            bool actualizado = await GestorDeDatos.Instancia().GestorTirador.ActualizarTirador(tirador);
            return actualizado;
        }

        public async Task GuardarInventario()
        {
            foreach (var itemConsumo in Inventario.ItemsConsumo.Values)
            {
                if (itemConsumo != null)
                {
                    await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(itemConsumo);
                }
            }

            foreach (var itemEquipo in Inventario.ItemsEquipo.Values)
            {
                if (itemEquipo != null)
                {
                    await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(itemEquipo);
                }
            }

            foreach (var maestria in Inventario.Maestrias.Values)
            {
                if (maestria != null)
                {
                    await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(maestria);
                }
            }

            foreach (var miscelanea in Inventario.Miscelanea.Values)
            {
                if (miscelanea != null)
                {
                    await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(miscelanea);
                }
            }

            Console.WriteLine("¡Inventario del tirador " + EntidadCombate.Nombre + " guardado correctamente!");
        }

        public byte Clase() { return (byte)Tipos.Clase.TIRADOR; }
    }
}