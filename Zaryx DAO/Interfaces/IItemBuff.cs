namespace Zaryx_DAO.Interfaces
{
    public interface IItemBuff
    {
        int IdItemBuff { get; set; }
        short ItemGenerador { get; set; }
        short BuffGenerador { get; set; }
        bool EsGrupal { get; set; }
    }
}
