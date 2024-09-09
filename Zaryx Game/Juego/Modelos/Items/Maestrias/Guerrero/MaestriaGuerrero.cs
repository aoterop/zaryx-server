using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;

namespace Zaryx_Game.Juego.Modelos.Items.Maestrias.Guerrero
{
    public class MaestriaGuerrero : Item, IMaestriaGuerrero
    {
        public byte NivelMinimo { get; set; }
        public byte NumeroMaestria { get; set; }

        public MaestriaGuerrero(MaestriaGuerreroDTO dto) : base(dto)
        {
            NivelMinimo = dto.NivelMinimo;
            NumeroMaestria = dto.NumeroMaestria;
        }

        public override byte Tipo() { return (byte)Tipos.Items.MAESTRIA_GUERRERO; }
    }
}