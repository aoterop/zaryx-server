using Zaryx_DAO;
using Zaryx_Game.Datos.Gestores;

namespace Zaryx_Game.Datos
{
    internal class GestorDeDatos
    {
        // Singleton.
        private static readonly GestorDeDatos _instancia = new();

        // Gestor de repos.
        private readonly GestorDeRepos _gestorDeRepos;

        // Gestores de modelos.
        private readonly GestorDeBuff _gestorBuff;
        private readonly GestorDeBuffHabilidad _gestorBuffHabilidad;
        private readonly GestorDeCuenta _gestorCuenta;
        private readonly GestorDeMapa _gestorMapa;
        private readonly GestorDeGuerrero _gestorGuerrero;
        private readonly GestorDeHabilidad _gestorHabilidad;
        private readonly GestorDeHabilidadBasicaGuerrero _gestorHabilidadBasicaGuerrero;
        private readonly GestorDeHabilidadBasicaTirador _gestorHabilidadBasicaTirador;
        private readonly GestorDeHabilidadMaestriaGuerrero _gestorHabilidadMaestriaGuerrero;
        private readonly GestorDeHabilidadMaestriaTirador _gestorHabilidadMaestriaTirador;
        private readonly GestorDeHabilidadMonstruo _gestorHabilidadMonstruo;
        private readonly GestorDeHabilidadBasicaGuerreroRelacion _gestorHabilidadBasicaGuerreroRelacion;
        private readonly GestorDeHabilidadBasicaTiradorRelacion _gestorHabilidadBasicaTiradorRelacion;
        private readonly GestorDeItem _gestorItem;
        private readonly GestorDeItemConsumo _gestorItemConsumo;
        private readonly GestorDeItemMiscelanea _gestorItemMiscelanea;
        private readonly GestorDeMaestriaGuerrero _gestorMaestriaGuerrero;
        private readonly GestorDeMaestriaTirador _gestorMaestriaTirador;
        private readonly GestorDeItemEquipo _gestorItemEquipo;
        private readonly GestorDeItemEquipoDefensivo _gestorItemEquipoDefensivo;
        private readonly GestorDeItemEquipoOfensivo _gestorItemEquipoOfensivo;
        private readonly GestorDeItemBuff _gestorItemBuff;
        private readonly GestorDeItemGuerrero _gestorItemGuerrero;
        private readonly GestorDeItemMonstruo _gestorItemMonstruo;
        private readonly GestorDeItemTienda _gestorItemTienda;
        private readonly GestorDeItemTirador _gestorItemTirador;
        private readonly GestorDeMonstruo _gestorMonstruo;
        private readonly GestorDeMonstruoMapa _gestorMonstruoMapa;
        private readonly GestorDePortal _gestorPortal;
        private readonly GestorDeTienda _gestorTienda;
        private readonly GestorDeTirador _gestorTirador;

        private GestorDeDatos()
        {
            _gestorDeRepos = GestorDeRepos.Instancia();

            _gestorBuff = new GestorDeBuff(_gestorDeRepos);
            _gestorBuffHabilidad = new GestorDeBuffHabilidad(_gestorDeRepos);
            _gestorCuenta = new GestorDeCuenta(_gestorDeRepos);
            _gestorMapa = new GestorDeMapa(_gestorDeRepos);
            _gestorGuerrero = new GestorDeGuerrero(_gestorDeRepos);
            _gestorHabilidad = new GestorDeHabilidad(_gestorDeRepos);
            _gestorHabilidadBasicaGuerrero = new GestorDeHabilidadBasicaGuerrero(_gestorDeRepos);
            _gestorHabilidadBasicaTirador = new GestorDeHabilidadBasicaTirador(_gestorDeRepos);
            _gestorHabilidadMaestriaGuerrero = new GestorDeHabilidadMaestriaGuerrero(_gestorDeRepos);
            _gestorHabilidadMaestriaTirador = new GestorDeHabilidadMaestriaTirador(_gestorDeRepos);
            _gestorHabilidadMonstruo = new GestorDeHabilidadMonstruo(_gestorDeRepos);
            _gestorHabilidadBasicaGuerreroRelacion = new GestorDeHabilidadBasicaGuerreroRelacion(_gestorDeRepos);
            _gestorHabilidadBasicaTiradorRelacion = new GestorDeHabilidadBasicaTiradorRelacion(_gestorDeRepos);
            _gestorItem = new GestorDeItem(_gestorDeRepos);
            _gestorItemConsumo = new GestorDeItemConsumo(_gestorDeRepos);
            _gestorItemMiscelanea = new GestorDeItemMiscelanea(_gestorDeRepos);
            _gestorMaestriaGuerrero = new GestorDeMaestriaGuerrero(_gestorDeRepos);
            _gestorMaestriaTirador = new GestorDeMaestriaTirador(_gestorDeRepos);
            _gestorItemEquipo = new GestorDeItemEquipo(_gestorDeRepos);
            _gestorItemEquipoDefensivo = new GestorDeItemEquipoDefensivo(_gestorDeRepos);
            _gestorItemEquipoOfensivo = new GestorDeItemEquipoOfensivo(_gestorDeRepos);
            _gestorItemBuff = new GestorDeItemBuff(_gestorDeRepos);
            _gestorItemGuerrero = new GestorDeItemGuerrero(_gestorDeRepos);
            _gestorItemMonstruo = new GestorDeItemMonstruo(_gestorDeRepos);
            _gestorItemTienda = new GestorDeItemTienda(_gestorDeRepos);
            _gestorItemTirador = new GestorDeItemTirador(_gestorDeRepos);
            _gestorMonstruo = new GestorDeMonstruo(_gestorDeRepos);
            _gestorMonstruoMapa = new GestorDeMonstruoMapa(_gestorDeRepos);
            _gestorPortal = new GestorDePortal(_gestorDeRepos);
            _gestorTienda = new GestorDeTienda(_gestorDeRepos);
            _gestorTirador = new GestorDeTirador(_gestorDeRepos);
        }

        //Singleton.
        public static GestorDeDatos Instancia() { return _instancia; }

        // Gestores de modelos.
        public GestorDeBuff GestorBuff { get { return _gestorBuff; } }
        public GestorDeBuffHabilidad GestorBuffHabilidad { get { return _gestorBuffHabilidad; } }
        public GestorDeCuenta GestorCuenta { get { return _gestorCuenta; } }
        public GestorDeMapa GestorMapa { get { return _gestorMapa; } }
        public GestorDeGuerrero GestorGuerrero { get { return _gestorGuerrero; } }
        public GestorDeHabilidad GestorHabilidad { get { return _gestorHabilidad; } }
        public GestorDeHabilidadBasicaGuerrero GestorHabilidadBasicaGuerrero { get { return _gestorHabilidadBasicaGuerrero; } }
        public GestorDeHabilidadBasicaTirador GestorHabilidadBasicaTirador { get { return _gestorHabilidadBasicaTirador; } }
        public GestorDeHabilidadMaestriaGuerrero GestorHabilidadMaestriaGuerrero { get { return _gestorHabilidadMaestriaGuerrero; } }
        public GestorDeHabilidadMaestriaTirador GestorHabildiadMaestriaTirador { get { return _gestorHabilidadMaestriaTirador; } }
        public GestorDeHabilidadMonstruo GestorHabilidadMonstruo { get { return _gestorHabilidadMonstruo; } }
        public GestorDeHabilidadBasicaGuerreroRelacion GestorHabilidadBasicaGuerreroRelacion { get { return _gestorHabilidadBasicaGuerreroRelacion; } }
        public GestorDeHabilidadBasicaTiradorRelacion GestorHabilidadBasicaTiradorRelacion { get { return _gestorHabilidadBasicaTiradorRelacion; } }
        public GestorDeItem GestorItem { get { return _gestorItem; } }
        public GestorDeItemConsumo GestorItemConsumo { get { return _gestorItemConsumo;} }
        public GestorDeItemMiscelanea GestorItemMiscelanea { get { return _gestorItemMiscelanea;} }
        public GestorDeMaestriaGuerrero GestorMaestriaGuerrero { get { return _gestorMaestriaGuerrero; } }
        public GestorDeMaestriaTirador GestorMaestriaTirador { get { return _gestorMaestriaTirador; } }
        public GestorDeItemEquipo GestorItemEquipo { get { return _gestorItemEquipo; } }
        public GestorDeItemEquipoDefensivo GestorItemEquipoDefensivo { get { return _gestorItemEquipoDefensivo; } }
        public GestorDeItemEquipoOfensivo GestorItemEquipoOfensivo { get { return _gestorItemEquipoOfensivo; } }
        public GestorDeItemBuff GestorItemBuff { get { return _gestorItemBuff;} }
        public GestorDeItemGuerrero GestorItemGuerrero { get { return _gestorItemGuerrero; } }
        public GestorDeItemMonstruo GestorItemMonstruo { get { return _gestorItemMonstruo; } }
        public GestorDeItemTienda GestorItemTienda { get { return _gestorItemTienda; } }
        public GestorDeItemTirador GestorItemTirador { get { return _gestorItemTirador; } }
        public GestorDeMonstruo GestorMonstruo { get { return _gestorMonstruo; } }
        public GestorDeMonstruoMapa GestorMonstruoMapa { get { return _gestorMonstruoMapa; } }
        public GestorDePortal GestorPortal { get { return _gestorPortal; } }
        public GestorDeTienda GestorTienda { get { return _gestorTienda; } }
        public GestorDeTirador GestorTirador { get { return _gestorTirador; } }
    }
}