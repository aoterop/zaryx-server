using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Cuenta : ICuenta
    {
        private long _idCuenta;
        private string _nombreCuenta = "";
        private string _email = "";
        private string _password = "";
        private bool _estaBloqueada;
        private bool _estaBaneada;

        public long IdCuenta { get { return _idCuenta; } set { _idCuenta = value; } }
        public string NombreCuenta { get { return _nombreCuenta; } set { _nombreCuenta = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public bool EstaBloqueada { get { return _estaBloqueada; } set { _estaBloqueada = value; } }
        public bool EstaBaneada { get { return _estaBaneada; } set { _estaBaneada = value; } }
    }
}