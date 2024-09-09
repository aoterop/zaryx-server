using Zaryx_DAO.Interfaces;

namespace Zaryx_Game.Datos.Modelos
{
    public class CuentaDTO
    {
        public long IdCuenta { get; set; }
        public string? NombreCuenta { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool EstaBloqueada { get; set; }
        public bool EstaBaneada { get; set; }

        public CuentaDTO(ICuenta cuenta)
        {
            this.IdCuenta = cuenta.IdCuenta;
            this.NombreCuenta = cuenta.NombreCuenta;
            this.Email = cuenta.Email;
            this.Password = cuenta.Password;
            this.EstaBloqueada = cuenta.EstaBloqueada;
            this.EstaBaneada = cuenta.EstaBaneada;
        }
    }
}