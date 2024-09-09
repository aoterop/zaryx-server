namespace Zaryx_Game.Juego.Modelos.Mapas
{
    public class Nodo
    {
        public short X { get; set; }
        public short Y { get; set; }
        public bool EsCaminable { get; set; }

        public Nodo(short x, short y, bool esCaminable)
        {
            X = x;
            Y = y;
            EsCaminable = esCaminable;
        }
    }
}