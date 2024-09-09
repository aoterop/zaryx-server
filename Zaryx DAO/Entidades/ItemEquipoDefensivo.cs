using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Entidades
{
    internal class ItemEquipoDefensivo : ItemEquipo, IItemEquipoDefensivo
    {
        private byte _tipoEquipoDefensivo;
        private short _defensaItem;
        private byte _velocidadExtra;

        public byte TipoEquipoDefensivo { get { return _tipoEquipoDefensivo; } set { _tipoEquipoDefensivo = value; } }
        public short DefensaItem { get { return _defensaItem; } set { _defensaItem = value; } }
        public byte VelocidadExtra { get { return _velocidadExtra; } set { _velocidadExtra = value; } }
    }
}