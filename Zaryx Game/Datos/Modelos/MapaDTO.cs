using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class MapaDTO
    {
        public short IdMapa { get; set; }
        public string NombreMapa { get; set; }
        public bool PermiteJcJ { get; set; }

        public MapaDTO(IMapa mapa)
        {
            this.IdMapa = mapa.IdMapa;
            this.NombreMapa = mapa.NombreMapa;
            this.PermiteJcJ = mapa.PermiteJcJ;
        }
    }
}