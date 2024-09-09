namespace Zaryx_Game.Juego.Modelos.Items
{
    public class ItemSuelo
    {
        public long IdItemSuelo { get; set; }
        public short IdItem { get; set; }
        public byte SeccionInventario { get; set; }
        public short Cantidad { get; set; }
        public short X { get; set; }
        public short Y { get; set; }

        public ItemSuelo(long idItemSuelo, short idItem, byte seccionInventario, short cantidad, short x, short y)
        {
            IdItemSuelo = idItemSuelo;
            IdItem = idItem;
            SeccionInventario = seccionInventario;
            Cantidad = cantidad;
            X = x;
            Y = y;
        }

        public ItemSuelo(short idItem, byte seccionInventario, short cantidad, short x, short y)
        {           
            IdItem = idItem;
            SeccionInventario = seccionInventario;
            Cantidad = cantidad;
            X = x;
            Y = y;
        }

        public ItemSuelo() { }
    }
}