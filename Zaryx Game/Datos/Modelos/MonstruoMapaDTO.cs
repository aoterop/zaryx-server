using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class MonstruoMapaDTO
    {
        public int IdMonstruoMapa { get; set; }
        public short ReferenciaMapa { get; set; }
        public short ReferenciaMonstruo { get; set; }
        public short PosicionX { get; set; }
        public short PosicionY { get; set; }
        public byte OrientacionMonstruo { get; set; }
        public bool PuedeMoverse { get; set; }

        public MonstruoMapaDTO(IMonstruoMapa monstruoMapa) 
        {
            this.IdMonstruoMapa = monstruoMapa.IdMonstruoMapa;
            this.ReferenciaMapa = monstruoMapa.ReferenciaMapa;
            this.ReferenciaMonstruo = monstruoMapa.ReferenciaMonstruo;
            this.PosicionX = monstruoMapa.PosicionX;
            this.PosicionY = monstruoMapa.PosicionY;
            this.OrientacionMonstruo = monstruoMapa.OrientacionMonstruo;
            this.PuedeMoverse = monstruoMapa.PuedeMoverse;
        }
    }
}