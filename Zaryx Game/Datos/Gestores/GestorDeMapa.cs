using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeMapa
    {
        private readonly IMapaRepository _mapaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeMapa(GestorDeRepos gestorDeRepos)
        {
            _mapaRepo = gestorDeRepos.MapaRepo;
        }

        public async Task<MapaDTO> ObtenerMapaPorId(short idMapa)
        {
            await _semaphore.WaitAsync();

            MapaDTO? mapa = null;

            try
            {
                IMapa iMapa = await _mapaRepo.ObtenerMapaPorId(idMapa);
                mapa = new MapaDTO(iMapa);
            }
            finally { _semaphore.Release(); }

            return mapa;
        }

        public async Task<List<MapaDTO>> ObtenerMapas()
        {
            await _semaphore.WaitAsync();

            List<MapaDTO> mapasFinales = new();

            try
            {
                List<IMapa> mapas = await _mapaRepo.ObtenerTodosLosMapas();

                foreach(var mapa in mapas)
                {
                    mapasFinales.Add(new MapaDTO(mapa));
                }
            }
            finally { _semaphore.Release(); }

            return mapasFinales;
        }
    }
}
