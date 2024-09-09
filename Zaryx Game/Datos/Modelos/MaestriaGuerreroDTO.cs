using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class MaestriaGuerreroDTO : ItemDTO
    {
        public byte NivelMinimo { get; set; }
        public byte NumeroMaestria { get; set; }

        public MaestriaGuerreroDTO(IMaestriaGuerrero item) : base(item)
        {
            this.NivelMinimo = item.NivelMinimo;
            this.NumeroMaestria = item.NumeroMaestria;
        }
    }
}