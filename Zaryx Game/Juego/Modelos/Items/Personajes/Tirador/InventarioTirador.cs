using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.Datos;
using Zaryx_Game.General;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador
{
    public class InventarioTirador
    {
        public Dictionary<byte, ItemTirador> ItemsConsumo { get; } = new Dictionary<byte, ItemTirador>();
        public Dictionary<byte, ItemTirador> ItemsEquipo { get; } = new Dictionary<byte, ItemTirador>();
        public Dictionary<byte, ItemTirador> Maestrias { get; } = new Dictionary<byte, ItemTirador>();
        public Dictionary<byte, ItemTirador> Miscelanea { get; } = new Dictionary<byte, ItemTirador>();

        private static readonly SemaphoreSlim semaphoreSlim = new(1, 1);


        public byte EncontrarRanuraDelItem(short idItem, Dictionary<byte, ItemTirador> seccion)
        {
            byte ranura = 255;

            foreach(var item in seccion)
            {
                if(item.Value.ReferenciaItem == idItem)
                {
                    ranura = item.Key;
                }
            }

            return ranura;
        }

        public byte EncontrarPrimeraRanuraLibre(Dictionary<byte, ItemTirador> seccion)
        {
            byte ranura = 255;

            for(byte i = 0; i < 40; i++)
            {
                if(!seccion.ContainsKey(i))
                {
                    ranura = i;
                    break;
                }
            }

            return ranura;
        }

        private async Task<bool> Agregar(ItemTirador item, byte idSesion, Dictionary<byte, ItemTirador> items, Tipos.SeccionesInventario seccion)
        {
            Console.WriteLine("Se agregará un item de: " + seccion);
            bool agregado = false;

            byte ranura = EncontrarRanuraDelItem(item.ReferenciaItem, items);

            if (ranura == 255 || seccion == Tipos.SeccionesInventario.MAESTRIA || seccion == Tipos.SeccionesInventario.EQUIPO)
            {// El tipo de item no existe.
                byte ranuraLibre = EncontrarPrimeraRanuraLibre(items);

                if (ranuraLibre != 255)
                {// Hay una ranura libre.
                    item.RanuraInventario = ranuraLibre;

                    long idItem = await GestorDeDatos.Instancia().GestorItemTirador.CrearItemTirador(item.Propietario, item.ReferenciaItem, item.Cantidad, 0, 0, item.RanuraInventario);

                    if (idItem != -1)
                    {
                        agregado = true;

                        item.IdItemPersonaje = idItem;
                        item.IdItemTirador = idItem;

                        items.Add(item.RanuraInventario, item);
                        MS_NuevoItemInventario ms = new(item.Cantidad, item.ReferenciaItem, (byte)seccion, ranuraLibre);
                        Emisor.Enviar(idSesion, ms.Tipo(), Serializador.Serializar(ms));
                    }
                }
                else {/* No hay espacio para el nuevo item. */}
            }
            else
            {// Ya existía ese tipo de ítem en el inventario.

                ItemTirador clon = items[ranura].Clone();
                clon.Cantidad += item.Cantidad;

                bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(clon);

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
                ItemTirador item = new();

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

                            ItemTirador item = ItemsConsumo[ranura2].Clone();
                            item.Cantidad += ItemsConsumo[ranura1].Cantidad;

                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(ItemsConsumo[ranura1].IdItemTirador);

                            if (result && result2)
                            {                               
                                ItemsConsumo[ranura2].Cantidad += ItemsConsumo[ranura1].Cantidad;
                                ItemsConsumo.Remove(ranura1);
                            }
                        }
                        else
                        {// Intercambio clásico.

                            ItemTirador item1 = ItemsConsumo[ranura1].Clone();
                            item1.RanuraInventario = ranura2;

                            ItemTirador item2 = ItemsConsumo[ranura2].Clone();
                            item2.RanuraInventario = ranura1;

                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item1);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item2);

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

                        ItemTirador item = ItemsConsumo[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);
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
                        ItemTirador item1 = ItemsEquipo[ranura1].Clone();
                        item1.RanuraInventario = ranura2;

                        ItemTirador item2 = ItemsEquipo[ranura2].Clone();
                        item2.RanuraInventario = ranura1;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item1);
                        bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item2);

                        if (result && result2)
                        {
                            ItemsEquipo[ranura1].RanuraInventario = ranura2;
                            ItemsEquipo[ranura2].RanuraInventario = ranura1;
                            (ItemsEquipo[ranura1], ItemsEquipo[ranura2]) = (ItemsEquipo[ranura2], ItemsEquipo[ranura1]);
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemTirador item = ItemsEquipo[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);

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
                        ItemTirador item1 = Maestrias[ranura1].Clone();
                        item1.RanuraInventario = ranura2;

                        ItemTirador item2 = Maestrias[ranura2].Clone();
                        item2.RanuraInventario = ranura1;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item1);
                        bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item2);

                        if (result && result2)
                        {
                            Maestrias[ranura1].RanuraInventario = ranura2;
                            Maestrias[ranura2].RanuraInventario = ranura1;
                            (Maestrias[ranura1], Maestrias[ranura2]) = (Maestrias[ranura2], Maestrias[ranura1]);
                        }
                    }
                    else
                    {// Cambio de posición.

                        ItemTirador item = Maestrias[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);

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

                            ItemTirador item = Miscelanea[ranura2].Clone();
                            item.Cantidad += Miscelanea[ranura1].Cantidad;

                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.EliminarItemTirador(Miscelanea[ranura1].IdItemTirador);

                            if (result && result2)
                            {
                                Miscelanea[ranura2].Cantidad += Miscelanea[ranura1].Cantidad;
                                Miscelanea.Remove(ranura1);
                            }
                        }
                        else
                        {// Intercambio clásico.
                            ItemTirador item1 = Miscelanea[ranura1].Clone();
                            item1.RanuraInventario = ranura2;

                            ItemTirador item2 = Miscelanea[ranura2].Clone();
                            item2.RanuraInventario = ranura1;

                            bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item1);
                            bool result2 = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item2);

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

                        ItemTirador item = Miscelanea[ranura1].Clone();
                        item.RanuraInventario = ranura2;

                        bool result = await GestorDeDatos.Instancia().GestorItemTirador.ActualizarItemTirador(item);
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
            switch (seccion)
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