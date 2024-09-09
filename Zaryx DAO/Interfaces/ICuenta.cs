namespace Zaryx_DAO.Interfaces
{
    public interface ICuenta
    {
        long IdCuenta { get; set; }
        string NombreCuenta { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        bool EstaBloqueada { get; set; }
        bool EstaBaneada { get; set; }
    }
}