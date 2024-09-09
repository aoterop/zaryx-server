using Zaryx_DAO.Interfaces;
using Zaryx_Game.Estructuras;
using Zaryx_Game.Juego.Modelos.Items;

namespace Zaryx_Game.Juego.Modelos.Entidades.Monstruos
{
    public class Monstruo /*: IMonstruo*/
    {
        public ListaSegura<Item> Drops;

        public Monstruo()
        {
            Drops = new ListaSegura<Item>();
        }
    }
}