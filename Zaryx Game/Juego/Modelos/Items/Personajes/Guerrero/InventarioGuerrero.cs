using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.Datos;
using Zaryx_Game.General;
using Zaryx_Game.Juego.Modelos.Items.Guerrero;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Juego.Modelos.Items.Personajes.Guerrero
{
    public class InventarioGuerrero
    {
        public Dictionary<byte, ItemGuerrero> ItemsConsumo { get; } = new Dictionary<byte, ItemGuerrero>();
        public Dictionary<byte, ItemGuerrero> ItemsEquipo { get; } = new Dictionary<byte, ItemGuerrero>();
        public Dictionary<byte, ItemGuerrero> Maestrias { get; } = new Dictionary<byte, ItemGuerrero>();
        public Dictionary<byte, ItemGuerrero> Miscelanea { get; } = new Dictionary<byte, ItemGuerrero>();

        private static readonly SemaphoreSlim semaphoreSlim = new(1, 1);

        public byte EncontrarRanuraDelItem(short idItem, Dictionary<byte, ItemGuerrero> seccion)
        {
            byte ranura = 255;

            foreach (var item in seccion)
            {
                if (item.Value.ReferenciaItem == idItem)
                {
                    ranura = item.Key;
                }
            }

            return ranura;
        }

        public byte EncontrarPrimeraRanuraLibre(Dictionary<byte, ItemGuerrero> seccion)
        {
            byte ranura = 255;

            for (byte i = 0; i < 40; i++)
            {
                if (!seccion.ContainsKey(i))
                {
                    ranura = i;
                    break;
                }
            }

            return ranura;
        }

        private async Task<bool> Agregar(ItemGuerrero item, byte idSesion, Dictionary<byte, ItemGuerrero> items, Tipos.SeccionesInventario seccion)
        {
            bool agregado = false;

            byte ranura = EncontrarRanuraDelItem(item.ReferenciaItem, items);

            if (ranura == 255 || seccion == Tipos.SeccionesInventario.MAESTRIA || seccion == Tipos.SeccionesInventario.EQUIPO)
            {// El tipo de item no existe.

                byte ranuraLibre = EncontrarPrimeraRanuraLibre(items);

                if (ranuraLibre != 255)
                {// Hay una ranura libre.
                    item.RanuraInventario = ranuraLibre;

                    long idItem = await GestorDeDatos.Instancia().GestorItemGuerrero.CrearItemGuerrero(item.Propietario, item.ReferenciaItem, item.Cantidad, 0, 0, item.RanuraInventario);

                    if (idItem != -1)
                    {
                        item.IdItemPersonaje = idItem;
                        item.IdItemGuerrero = idItem;

                        agregado = true;

                        items.Add(item.RanuraInventario, item);
                        Console.WriteLine("Se ha guardado el item: (ranura)" + items[item.RanuraInventario].RanuraInventario + " " +
                            "(ref del item)" + items[item.RanuraInventario].ReferenciaItem + " y cantidad: " + items[item.RanuraInventario].Cantidad);

                        MS_NuevoItemInventario ms = new(item.Cantidad, item.ReferenciaItem, (byte)seccion, ranuraLibre);
                        Emisor.Enviar(idSesion, ms.Tipo(), Serializador.Serializar(ms));
                    }
                }
                else {/* No hay espacio para el nuevo item. */}
            }
            else
            {// Ya existía ese tipo de ítem en el inventario.

                ItemGuerrero clon = items[ranura].Clone();
                clon.Cantidad += item.Cantidad;

                bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(clon);

                if (result)
                {
                    agregado = true;

                    items[ranura].Cantidad += item.Cantidad;
                    MS_AumentoCantidadItemInventario ms = new(item.Cantidad, (byte)seccion, ranura);
                    Emisor.Enviar(idSesion, ms.Tipo(), Serializador.Serializar(ms));
                }
            }

            return agregado;
        }

        public async Task<bool> AgregarItem(short idItem, byte seccionInventario, short cantidad, long idPersonaje, byte idSesion)
        {
            bool agregado = false;

            await semaphoreSlim.WaitAsync();

            try
            {
                ItemGuerrero item = new();

                item.Propietario = idPersonaje;
                item.Cantidad = cantidad;
                item.ReferenciaItem = idItem;

                switch (seccionInventario)
                {
                    case (byte)Tipos.SeccionesInventario.CONSUMO: { agregado = await Agregar(item, idSesion, ItemsConsumo, Tipos.SeccionesInventario.CONSUMO); } break;
                    case (byte)Tipos.SeccionesInventario.EQUIPO: { agregado = await Agregar(item, idSesion, ItemsEquipo, Tipos.SeccionesInventario.EQUIPO); } break;
                    case (byte)Tipos.SeccionesInventario.MAESTRIA: { agregado = await Agregar(item, idSesion, Maestrias, Tipos.SeccionesInventario.MAESTRIA); } break;
                    case (byte)Tipos.SeccionesInventario.MISCELANEA: { agregado = await Agregar(item, idSesion, Miscelanea, Tipos.SeccionesInventario.MISCELANEA); } break;

                    default: { } break;
                }

            }
            finally { semaphoreSlim.Release(); }

            return agregado;
        }
        
        public async Task IntercambiarItemsConsumo(byte ranura1, byte ranura2)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                if (ItemsConsumo.ContainsKey(ranura1))
                {
                    if (ItemsConsumo.ContainsKey(ranura2))
                    {
                        if (ItemsConsumo[ranura1].ReferenciaItem == ItemsConsumo[ranura2].ReferenciaItem)
                        {// Fusión de objetos en la segunda ranura.

                            ItemGuerrero item = ItemsConsumo[ranura2].Clone();
                            item.Cantidad += ItemsConsumo[ranura1].Cantidad;

                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(ItemsConsumo[ranura1].IdItemGuerrero);

                            if (result && result2)
                            {                               
                                ItemsConsumo[ranura2].Cantidad += ItemsConsumo[ranura1].Cantidad;
                                ItemsConsumo.Remove(ranura1);
                            }
                        }
                        else
                        {// Intercambio clásico.

                            ItemGuerrero item1 = ItemsConsumo[ranura1].Clone();
                            item1.RanuraInventario = ranura2;

                            ItemGuerrero item2 = ItemsConsumo[ranura2].Clone();
                            item2.RanuraInventario = ranura1;

                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item1);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item2);

                            if (result && result2)
                            {
                                ItemsConsumo[ranura1].RanuraInventario = ranura2;
                                ItemsConsumo[ranura2].RanuraInventario = ranura1;
                                (ItemsConsumo[ranura1], ItemsConsumo[ranura2]) = (ItemsConsumo[ranura2], ItemsConsumo[ranura1]);
                            }
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemGuerrero item = ItemsConsumo[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);
                        if (result)
                        {
                            ItemsConsumo.Add(ranura2, ItemsConsumo[ranura1]);
                            ItemsConsumo[ranura2].RanuraInventario = ranura2;
                            ItemsConsumo.Remove(ranura1);
                        }
                    }
                }
            }
            finally { semaphoreSlim.Release(); }
        }

        public async Task IntercambiarItemsEquipo(byte ranura1, byte ranura2)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                if (ItemsEquipo.ContainsKey(ranura1))
                {
                    if (ItemsEquipo.ContainsKey(ranura2))
                    {
                        ItemGuerrero item1 = ItemsEquipo[ranura1].Clone();
                        item1.RanuraInventario = ranura2;

                        ItemGuerrero item2 = ItemsEquipo[ranura2].Clone();
                        item2.RanuraInventario = ranura1;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item1);
                        bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item2);

                        if (result && result2)
                        {
                            ItemsEquipo[ranura1].RanuraInventario = ranura2;
                            ItemsEquipo[ranura2].RanuraInventario = ranura1;
                            (ItemsEquipo[ranura1], ItemsEquipo[ranura2]) = (ItemsEquipo[ranura2], ItemsEquipo[ranura1]);
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemGuerrero item = ItemsEquipo[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);

                        if (result)
                        {
                            ItemsEquipo.Add(ranura2, ItemsEquipo[ranura1]);
                            ItemsEquipo[ranura2].RanuraInventario = ranura2;
                            ItemsEquipo.Remove(ranura1);
                        }
                    }
                }
            }
            finally { semaphoreSlim.Release(); }
        }

        public async Task IntercambiarMaestrias(byte ranura1, byte ranura2)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                if (Maestrias.ContainsKey(ranura1))
                {
                    if (Maestrias.ContainsKey(ranura2))
                    {
                        ItemGuerrero item1 = Maestrias[ranura1].Clone();
                        item1.RanuraInventario = ranura2;

                        ItemGuerrero item2 = Maestrias[ranura2].Clone();
                        item2.RanuraInventario = ranura1;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item1);
                        bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item2);

                        if (result && result2)
                        {
                            Maestrias[ranura1].RanuraInventario = ranura2;
                            Maestrias[ranura2].RanuraInventario = ranura1;
                            (Maestrias[ranura1], Maestrias[ranura2]) = (Maestrias[ranura2], Maestrias[ranura1]);
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemGuerrero item = Maestrias[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);

                        if (result)
                        {
                            Maestrias.Add(ranura2, Maestrias[ranura1]);
                            Maestrias[ranura2].RanuraInventario = ranura2;
                            Maestrias.Remove(ranura1);
                        }
                    }
                }
            }
            finally { semaphoreSlim.Release(); }
        }

        public async Task IntercambiarMiscelanea(byte ranura1, byte ranura2)
        {
            await semaphoreSlim.WaitAsync();

            try
            {
                if (Miscelanea.ContainsKey(ranura1))
                {
                    if (Miscelanea.ContainsKey(ranura2))
                    {
                        if (Miscelanea[ranura1].ReferenciaItem == Miscelanea[ranura2].ReferenciaItem)
                        {// Fusión de objetos en la segunda ranura.

                            ItemGuerrero item = Miscelanea[ranura2].Clone();
                            item.Cantidad += Miscelanea[ranura1].Cantidad;

                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.EliminarItemGuerrero(Miscelanea[ranura1].IdItemGuerrero);

                            if (result && result2)
                            {
                                Miscelanea[ranura2].Cantidad += Miscelanea[ranura1].Cantidad;
                                Miscelanea.Remove(ranura1);
                            }
                        }
                        else
                        {// Intercambio clásico.
                            ItemGuerrero item1 = Miscelanea[ranura1].Clone();
                            item1.RanuraInventario = ranura2;

                            ItemGuerrero item2 = Miscelanea[ranura2].Clone();
                            item2.RanuraInventario = ranura1;

                            bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item1);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item2);

                            if (result && result2)
                            {
                                Miscelanea[ranura1].RanuraInventario = ranura2;
                                Miscelanea[ranura2].RanuraInventario = ranura1;
                                (Miscelanea[ranura1], Miscelanea[ranura2]) = (Miscelanea[ranura2], Miscelanea[ranura1]);
                            }
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemGuerrero item = Miscelanea[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemGuerrero.ActualizarItemGuerrero(item);
                        if (result)
                        {
                            Miscelanea.Add(ranura2, Miscelanea[ranura1]);
                            Miscelanea[ranura2].RanuraInventario = ranura2;
                            Miscelanea.Remove(ranura1);
                        }
                    }
                }
            }
            finally { semaphoreSlim.Release(); }
        }

        public void EliminarItem(byte seccion, byte ranura)
        {
            switch(seccion) 
            {
                case (byte)Tipos.SeccionesInventario.CONSUMO: { EliminarItemConsumo(ranura); } break;
                case (byte)Tipos.SeccionesInventario.EQUIPO: { EliminarItemEquipo(ranura); } break;
                case (byte)Tipos.SeccionesInventario.MAESTRIA: { EliminarItemMaestria(ranura); } break;
                case (byte)Tipos.SeccionesInventario.MISCELANEA: { EliminarItemMiscelanea(ranura); } break;

                default: { } break;
            }
        }

        public void EliminarItemConsumo(byte ranura)
        {
            lock (ItemsConsumo)
            {
                ItemsConsumo.Remove(ranura);
            }
        }

        public void EliminarItemEquipo(byte ranura)
        {
            lock (ItemsEquipo)
            {
                ItemsEquipo.Remove(ranura);
            }
        }

        public void EliminarItemMaestria(byte ranura)
        {
            lock (Maestrias)
            {
                Maestrias.Remove(ranura);
            }
        }

        public void EliminarItemMiscelanea(byte ranura)
        {
            lock (Miscelanea)
            {
                Miscelanea.Remove(ranura);
            }
        }
    }
}