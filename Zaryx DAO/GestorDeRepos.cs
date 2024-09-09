using Zaryx_DAO.Implementaciones;
using Zaryx_DAO.Repositorios.Implementacioens;
using Zaryx_DAO.Repositorios.Interfaces;
using System.Configuration;
using Zaryx_DAO.DAO.Implementaciones;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO
{
    public class GestorDeRepos
    {
        // Singleton.
        private static readonly GestorDeRepos _instancia = new();

        // Cadena de conexión.
        private readonly string _conex = "";

        // Repositorios.
        internal readonly IBuffRepository _buffRepo;
        internal readonly IBuffHabilidadRepository _buffHabilidadRepo;
        internal readonly ICuentaRepository _cuentaRepo;
        internal readonly IGuerreroRepository _guerreroRepo;
        internal readonly IHabilidadRepository<IHabilidad> _habilidadRepo;
        internal readonly IHabilidadBasicaGuerreroRepository _habilidadBasicaGuerreroRepo;
        internal readonly IHabilidadBasicaTiradorRepository _habilidadBasicaTiradorRepo;
        internal readonly IHabilidadMaestriaGuerreroRepository _habilidadMaestriaGuerreroRepo;
        internal readonly IHabilidadMaestriaTiradorRepository _habilidadMaestriaTiradorRepo;
        internal readonly IHabilidadMonstruoRepository _habilidadMonstruoRepo;
        internal readonly IHabilidadBasicaGuerreroRelacionRepository _habilidadBasicaGuerreroRelacionRepo;
        internal readonly IHabilidadBasicaTiradorRelacionRepository _habilidadBasicaTiradorRelacionRepo;
        internal readonly IItemRepository<IItem> _itemRepo;
        internal readonly IItemConsumoRepository _itemConsumoRepo;
        internal readonly IItemMiscelaneaRepository _itemMiscelaneaRepo;
        internal readonly IMaestriaGuerreroRepository _maestriaGuerrerRepo;
        internal readonly IMaestriaTiradorRepository _maestriaTiradorRepo;
        internal readonly IItemEquipoRepository<IItemEquipo> _itemEquipoRepo;
        internal readonly IItemEquipoDefensivoRepository _itemEquipoDefensivoRepo;
        internal readonly IItemEquipoOfensivoRepository _itemEquipoOfensivoRepo;
        internal readonly IItemBuffRepository _itemBuffRepo;
        internal readonly IItemGuerreroRepository _itemGuerreroRepo;
        internal readonly IItemTiradorRepository _itemTiradorRepo;
        internal readonly IItemMonstruoRepository _itemMonstruoRepo;
        internal readonly IItemTiendaRepository _itemTiendaRepo;
        internal readonly IMapaRepository _mapaRepo;
        internal readonly IMonstruoRepository _monstruoRepo;
        internal readonly IMonstruoMapaRepository _monstruoMapaRepo;
        internal readonly IPortalRepository _portalRepo;
        internal readonly ITiendaRepository _tiendaRepo;
        internal readonly ITiradorRepository _tiradorRepo;

        private GestorDeRepos()
        {
            _conex = ConfigurationManager.ConnectionStrings["conex"].ConnectionString;

            // Creación de una instancia de cada uno de los repositorios.
            _buffRepo = new BuffRepository(new ImplBuffDao(_conex));
            _buffHabilidadRepo = new BuffHabilidadRepository(new ImplBuffHabilidadDao(_conex));
            _cuentaRepo = new CuentaRepository(new ImplCuentaDao(_conex));
            _guerreroRepo = new GuerreroRepository(new ImplGuerreroDao(_conex));
            _habilidadRepo = new HabilidadRepository(new ImplHabilidadDao(_conex));
            _habilidadBasicaGuerreroRepo = new HabilidadBasicaGuerreroRepository(new ImplHabilidadBasicaGuerreroDao(_conex));
            _habilidadBasicaTiradorRepo = new HabilidadBasicaTiradorRepository(new ImplHabilidadBasicaTiradorDao(_conex));
            _habilidadMaestriaGuerreroRepo = new HabilidadMaestriaGuerreroRepository(new ImplHabilidadMaestriaGuerreroDao(_conex));
            _habilidadMaestriaTiradorRepo = new HabilidadMaestriaTiradorRepository(new ImplHabilidadMaestriaTiradorDao(_conex));
            _habilidadMonstruoRepo = new HabilidadMonstruoRepository(new ImplHabilidadMonstruoDao(_conex));
            _habilidadBasicaGuerreroRelacionRepo = new HabilidadBasicaGuerreroRelacionRepository(new ImplHabilidadBasicaGuerreroRelacionDao(_conex));
            _habilidadBasicaTiradorRelacionRepo = new HabilidadBasicaTiradorRelacionRepository(new ImplHabilidadBasicaTiradorRelacionDao(_conex));
            _itemRepo = new ItemRepository(new ImplItemDao(_conex));
            _itemConsumoRepo = new ItemConsumoRepository(new ImplItemConsumoDao(_conex));
            _itemMiscelaneaRepo = new ItemMiscelaneaRepository(new ImplItemMiscelaneaDao(_conex));
            _maestriaGuerrerRepo = new MaestriaGuerreroRepository(new ImplMaestriaGuerreroDao(_conex));
            _maestriaTiradorRepo = new MaestriaTiradorRepository(new ImplMaestriaTiradorDao(_conex));
            _itemEquipoRepo = new ItemEquipoRepository(new ImplItemEquipoDao(_conex));
            _itemEquipoDefensivoRepo = new ItemEquipoDefensivoRepository(new ImplItemEquipoDefensivoDao(_conex));
            _itemEquipoOfensivoRepo = new ItemEquipoOfensivoRepository(new ImplItemEquipoOfensivoDao(_conex));
            _itemBuffRepo = new ItemBuffRepository(new ImplItemBuffDao(_conex));
            _itemGuerreroRepo = new ItemGuerreroRepository(new ImplItemGuerreroDao(_conex));
            _itemTiradorRepo = new ItemTiradorRepository(new ImplItemTiradorDao(_conex));
            _itemMonstruoRepo = new ItemMonstruoRepository(new ImplItemMonstruoDao(_conex));
            _itemTiendaRepo = new ItemTiendaRepository(new ImplItemTiendaDao(_conex));
            _mapaRepo = new MapaRepository(new ImplMapaDao(_conex));
            _monstruoRepo = new MonstruoRepository(new ImplMonstruoDao(_conex));
            _monstruoMapaRepo = new MonstruoMapaRepository(new ImplMonstruoMapaDao(_conex));
            _portalRepo = new PortalRepository(new ImplPortalDao(_conex));
            _tiendaRepo = new TiendaRepository(new ImplTiendaDao(_conex));
            _tiradorRepo = new TiradorRepository(new ImplTiradorDao(_conex));
        }

        public static GestorDeRepos Instancia() { return _instancia; }
        public IBuffRepository BuffRepo { get { return _buffRepo; } }
        public IBuffHabilidadRepository BuffHabilidadRepo { get { return _buffHabilidadRepo; } }
        public ICuentaRepository CuentaRepo { get { return _cuentaRepo;} }
        public IGuerreroRepository GuerreroRepo { get { return _guerreroRepo;} }
        public IHabilidadRepository<IHabilidad> HabilidadRepo {  get { return _habilidadRepo;} }
        public IHabilidadBasicaGuerreroRepository HabilidadBasicaGuerreroRepo { get { return _habilidadBasicaGuerreroRepo; } }
        public IHabilidadBasicaTiradorRepository HabilidadBasicaTiradorRepo { get { return _habilidadBasicaTiradorRepo; } }
        public IHabilidadMaestriaGuerreroRepository HabilidadMaestriaGuerreroRepo { get { return _habilidadMaestriaGuerreroRepo; } }
        public IHabilidadMaestriaTiradorRepository HabilidadMaestriaTiradorRepo { get { return _habilidadMaestriaTiradorRepo;} }
        public IHabilidadMonstruoRepository HabilidadMonstruoRepo { get { return _habilidadMonstruoRepo; } }
        public IHabilidadBasicaGuerreroRelacionRepository HabilidadBasicaGuerreroRelacionRepo { get { return _habilidadBasicaGuerreroRelacionRepo; } }
        public IHabilidadBasicaTiradorRelacionRepository HabilidadBasicaTiradorRelacionRepo { get { return _habilidadBasicaTiradorRelacionRepo; } }
        public IItemRepository<IItem> ItemRepo { get { return _itemRepo; } }
        public IItemConsumoRepository ItemConsumoRepo { get { return _itemConsumoRepo; } }
        public IItemMiscelaneaRepository ItemMiscelaneaRepo { get { return _itemMiscelaneaRepo;} }
        public IMaestriaGuerreroRepository MaestriaGuerreroRepo { get { return _maestriaGuerrerRepo; } }
        public IMaestriaTiradorRepository MaestriaTiradorRepo { get { return _maestriaTiradorRepo; } }
        public IItemEquipoRepository<IItemEquipo> ItemEquipoRepo { get { return _itemEquipoRepo;} }
        public IItemEquipoDefensivoRepository ItemEquipoDefensivoRepo { get { return _itemEquipoDefensivoRepo; } }
        public IItemEquipoOfensivoRepository ItemEquipoOfensivoRepo { get { return _itemEquipoOfensivoRepo; } }
        public IItemBuffRepository ItemBuffRepo { get { return _itemBuffRepo; } }
        public IItemGuerreroRepository ItemGuerreroRepo { get { return _itemGuerreroRepo; } }
        public IItemTiradorRepository ItemTiradorRepo { get { return _itemTiradorRepo; } }
        public IItemMonstruoRepository ItemMonstruoRepo { get { return _itemMonstruoRepo;} }
        public IItemTiendaRepository ItemTiendaRepo { get { return _itemTiendaRepo;} }
        public IMapaRepository MapaRepo { get { return _mapaRepo; } }
        public IMonstruoRepository MonstruoRepo { get { return _monstruoRepo;} }
        public IMonstruoMapaRepository MonstruoMapaRepo { get { return _monstruoMapaRepo; } }
        public IPortalRepository PortalRepo { get { return _portalRepo; } }
        public ITiendaRepository TiendaRepo { get { return _tiendaRepo; } }
        public ITiradorRepository TiradorRepo { get { return _tiradorRepo; } }
    }
}