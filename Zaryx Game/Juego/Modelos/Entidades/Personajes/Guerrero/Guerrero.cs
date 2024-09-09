using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Items.Guerrero;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Guerrero;

namespace Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero
{
    public class Guerrero : IPersonaje
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
        public InventarioGuerrero Inventario { get; set; }

        public Guerrero(GuerreroDTO dto, byte idSesion)
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

            Inventario = new InventarioGuerrero();
        }            

        public async Task CargarInventario()
        {
            List<ItemGuerreroDTO> items = await GestorDeDatos.Instancia().GestorItemGuerrero.ObtenerTodosLosItemsDeUnGuerrero(IdPersonaje);

            foreach(var item in items)
            {
                switch(GestorJuego.Instancia().GestorItems.ObtenerItem(item.ReferenciaItem)?.Item2.Tipo())
                {
                    case (byte)Tipos.Items.CONSUMO:
                        {
                            Inventario.ItemsConsumo.Add(item.RanuraInventario, new ItemGuerrero(item));
                        }break;

                    case (byte)Tipos.Items.EQUIPO_DEFENSIVO:
                    case (byte)Tipos.Items.EQUIPO_OFENSIVO:
                        {
                            Inventario.ItemsEquipo.Add(item.RanuraInventario, new ItemGuerrero(item));
                        }
                        break;

                    case (byte)Tipos.Items.MAESTRIA_GUERRERO:
                    case (byte)Tipos.Items.MAESTRIA_TIRADOR:
                        {
                            Inventario.Maestrias.Add(item.RanuraInventario, new ItemGuerrero(item));
                        }
                        break;


                    case (byte)Tipos.Items.MISCELANEA:
                        {
                            Inventario.Miscelanea.Add(item.RanuraInventario, new ItemGuerrero(item));
                        }
                        break;

                    default: { } break;
                }
            }
        }

        public async Task<ItemGuerrero?> EliminarItem(byte seccion, byte ranura)
        {
            ItemGuerrero? item = null;
            switch (seccion)
            {
                case (byte)Tipos.SeccionesInventario.CONSUMO:
                    {
                        if (Inventario.ItemsConsumo[ranura] != null)
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(Inventario.ItemsConsumo[ranura]!.IdItemGuerrero);
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
                        if (Inventario.ItemsEquipo[ranura] != null)
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(Inventario.ItemsEquipo[ranura]!.IdItemGuerrero);
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
                        if (Inventario.Maestrias[ranura] != null)
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(Inventario.Maestrias[ranura]!.IdItemGuerrero);
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
                        if (Inventario.Miscelanea[ranura] != null)
                        {
                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(Inventario.Miscelanea[ranura]!.IdItemGuerrero);
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
            IGuerrero guerrero = GestorDeDatos.Instancia().GestorGuerrero.CrearGuerrero();

            guerrero.IdPersonaje = IdPersonaje;
            guerrero.NivelPersonaje = EntidadCombate.Nivel;
            guerrero.CuentaAsociada = CuentaAsociada;
            guerrero.NombrePersonaje = EntidadCombate.Nombre!;
            guerrero.Peinado = Peinado;
            guerrero.AspectoFacial = AspectoFacial;
            guerrero.EsAdmin = EsAdmin;
            guerrero.TiempoJugado = TiempoJugado + (int)(DateTime.Now - MomentoInicio).TotalSeconds;
            guerrero.UltimoHp = EntidadCombate.Hp;
            guerrero.UltimoMp = EntidadCombate.Mp;
            guerrero.Monedas = Monedas;
            guerrero.NivelPersonaje = EntidadCombate.Nivel;
            guerrero.UltimoMapa = EntidadCombate.Mapa;
            guerrero.UltimoMapaX = EntidadCombate.X;
            guerrero.UltimoMapaY = EntidadCombate.Y;
            guerrero.ExperienciaPersonaje = EntidadCombate.Experiencia;
            guerrero.EstaSilenciado = EstaSilenciado;

            EntidadCombate.NodosPorRecorrer.Dispose();

            await GuardarInventario();

            bool actualizado = await GestorDeDatos.Instancia().GestorGuerrero.ActualizarGuerrero(guerrero);
            return actualizado;
        }

        public async Task GuardarInventario()
        {   
            foreach (var itemConsumo in Inventario.ItemsConsumo.Values)
            {
                if (itemConsumo != null)
                {
                    await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(itemConsumo);
                }
            }

            foreach (var itemEquipo in Inventario.ItemsEquipo.Values)
            {
                if (itemEquipo != null)
                {
                    await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(itemEquipo);
                }
            }

            foreach (var maestria in Inventario.Maestrias.Values)
            {
                if (maestria != null)
                {
                    await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(maestria);
                }
            }

            foreach (var miscelanea in Inventario.Miscelanea.Values)
            {
                if (miscelanea != null)
                {
                    await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(miscelanea);
                }
            }

            Console.WriteLine("¡Inventario del guerrero " + EntidadCombate.Nombre + " guardado correctamente!");
        }

        public byte Clase() { return (byte)Tipos.Clase.GUERRERO; }
    }
}