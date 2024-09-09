using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class MaestriaTiradorDTO : ItemDTO
    {
        public byte NivelMinimo { get; set; }
        public byte NumeroMaestria { get; set; }


        public MaestriaTiradorDTO(IMaestriaTirador item) : base(item)
        {
            this.NivelMinimo = item.NivelMinimo;
            this.NumeroMaestria= item.NumeroMaestria;
        }
    }
}