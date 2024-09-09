namespace Zaryx_DAO.Interfaces
{
    public interface IBuff
    {
        short IdBuff { get; set; }
        string NombreBuff { get; set; }
        string? DetallesBuff { get; set; }
        int DuracionBuff { get; set; }
        short AumentoVelocidad { get; set; }
        short AumentoDefensa { get; set; }
        short AumentoAtaque { get; set; }
        bool AntiCritico { get; set; }
        bool Inmortalidad { get; set; }
        bool Inmovilidad { get; set; }
        bool Shock { get; set; }
        short? SiguienteBuff { get; set; }
    }
}