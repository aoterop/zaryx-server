using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class BuffHabilidadDTO
    {
        public int IdHabilidadBuff { get; set; }
        public short BuffProducido { get; set; }
        public short HabilidadAsociada { get; set; }
        public int ProbabilidadExito { get; set; }

        public BuffHabilidadDTO(IBuffHabilidad buffHabilidad)
        {
            this.IdHabilidadBuff = buffHabilidad.IdHabilidadBuff;
            this.BuffProducido = buffHabilidad.BuffProducido;
            this.HabilidadAsociada = buffHabilidad.HabilidadAsociada;
            this.ProbabilidadExito = buffHabilidad.ProbabilidadExito;
        }
    }
}