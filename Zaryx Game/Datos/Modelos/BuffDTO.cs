using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class BuffDTO
    {
        public short IdBuff { get; set; }
        public string NombreBuff { get; set; }
        public string? DetallesBuff { get; set; }
        public int DuracionBuff { get; set; }
        public short AumentoVelocidad { get; set; }
        public short AumentoDefensa { get; set; }
        public short AumentoAtaque { get; set; }
        public bool AntiCritico { get; set; }
        public bool Inmortalidad { get; set; }
        public bool Inmovilidad { get; set; }
        public bool Shock { get; set; }
        public short? SiguienteBuff { get; set; }

        public BuffDTO(IBuff iBuff)
        {
            this.IdBuff = iBuff.IdBuff;
            this.NombreBuff = iBuff.NombreBuff;
            this.DetallesBuff = iBuff.DetallesBuff;
            this.DuracionBuff = iBuff.DuracionBuff;
            this.AumentoVelocidad = iBuff.AumentoVelocidad;
            this.AumentoDefensa = iBuff.AumentoDefensa;
            this.AumentoAtaque = iBuff.AumentoAtaque;
            this.AntiCritico = iBuff.AntiCritico;
            this.Inmortalidad = iBuff.Inmortalidad;
            this.Inmovilidad = iBuff.Inmovilidad;
            this.Shock = iBuff.Shock;
            this.SiguienteBuff = iBuff.SiguienteBuff;
        }
    }
}