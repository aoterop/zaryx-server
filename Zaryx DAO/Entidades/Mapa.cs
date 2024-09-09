using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class Mapa : IMapa
    {
        private short _idMapa;
        private string _nombreMapa = "";
        private bool _permiteJcJ;

        public short IdMapa { get { return _idMapa; } set { _idMapa = value; } }
        public string NombreMapa { get { return _nombreMapa; } set { _nombreMapa = value; } }
        public bool PermiteJcJ { get { return _permiteJcJ; } set { _permiteJcJ = value; } }
    }
}