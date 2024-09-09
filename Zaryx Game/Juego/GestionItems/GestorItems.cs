using System.Collections.Concurrent;
using System.Collections.Generic;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Items;
using Zaryx_Game.Juego.Modelos.Items.Consumibles;
using Zaryx_Game.Juego.Modelos.Items.Equipo.Defensivo;
using Zaryx_Game.Juego.Modelos.Items.Equipo.Ofensivo;
using Zaryx_Game.Juego.Modelos.Items.Maestrias.Guerrero;
using Zaryx_Game.Juego.Modelos.Items.Maestrias.Tirador;
using Zaryx_Game.Juego.Modelos.Items.Miscelanea;

namespace Zaryx_Game.Juego.GestionItems
{
    public class GestorItems
    {
        private readonly ConcurrentDictionary<short, Tuple<byte, Item>> Items; // <id, <seccion, Item>>.

        public GestorItems()
        {
            Items = new ConcurrentDictionary<short, Tuple<byte, Item>>();
        }


        public Tuple<byte, Item>? ObtenerItem(short idItem)
        {
            Items.TryGetValue(idItem, out Tuple<byte, Item>? item);
            return item;
        }

        public async Task CargarItems()
        {
            List<ItemConsumoDTO> consumibles;
            List<ItemEquipoDefensivoDTO> equiposDefensivos;
            List<ItemEquipoOfensivoDTO> equiposOfensivos;
            List<MaestriaGuerreroDTO> maestriasGuerrero;
            List<MaestriaTiradorDTO> maestriasTirador;
            List<ItemMiscelaneaDTO> miscelaneas;

            consumibles = await GestorDeDatos.Instancia().GestorItemConsumo.ObtenerTodosLosItems();
            equiposDefensivos = await GestorDeDatos.Instancia().GestorItemEquipoDefensivo.ObtenerTodosLosItems();
            equiposOfensivos = await GestorDeDatos.Instancia().GestorItemEquipoOfensivo.ObtenerTodosLosItems();
            maestriasGuerrero = await GestorDeDatos.Instancia().GestorMaestriaGuerrero.ObtenerTodosLosItems();
            maestriasTirador = await GestorDeDatos.Instancia().GestorMaestriaTirador.ObtenerTodosLosItems();
            miscelaneas = await GestorDeDatos.Instancia().GestorItemMiscelanea.ObtenerTodosLosItems();

            foreach(var consumible in consumibles)
            {
                Items.TryAdd(consumible.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.CONSUMO, new ItemConsumo(consumible)));   
            }

            foreach(var equipoDefensivo in equiposDefensivos)
            {
                Items.TryAdd(equipoDefensivo.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.EQUIPO, new ItemEquipoDefensivo(equipoDefensivo)));
            }

            foreach(var equipoOfensivo in equiposOfensivos)
            {
                Items.TryAdd(equipoOfensivo.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.EQUIPO, new ItemEquipoOfensivo(equipoOfensivo)));
            }

            foreach(var maestriaGuerrero in maestriasGuerrero)
            {
                Items.TryAdd(maestriaGuerrero.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.MAESTRIA, new MaestriaGuerrero(maestriaGuerrero)));
            }

            foreach(var maestriaTirador in maestriasTirador)
            {
                Items.TryAdd(maestriaTirador.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.MAESTRIA, new MaestriaTirador(maestriaTirador)));
            }

            foreach (var miscelanea in miscelaneas)
            {
                Items.TryAdd(miscelanea.IdItem, new Tuple<byte, Item>((byte)Tipos.SeccionesInventario.MISCELANEA, new ItemMiscelanea(miscelanea)));
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¡" + Items.Count + " items cargados!");
        }
    }
}