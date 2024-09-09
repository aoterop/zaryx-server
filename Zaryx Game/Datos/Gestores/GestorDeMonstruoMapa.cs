using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeMonstruoMapa
    {
        private readonly IMonstruoMapaRepository _monstruoMapaRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeMonstruoMapa(GestorDeRepos gestorDeRepos)
        {
            _monstruoMapaRepo = gestorDeRepos.MonstruoMapaRepo;
        }

        public async Task<MonstruoMapaDTO> ObtenerMonstruoMapaPorId(int idMonstruoMapa)
        {
            await _semaphore.WaitAsync();

            MonstruoMapaDTO? monstruoMapa = null;

            try
            { 
                IMonstruoMapa iMonstruoMapa = await _monstruoMapaRepo.ObtenerMonstruoMapaPorId(idMonstruoMapa);
                monstruoMapa = new MonstruoMapaDTO(iMonstruoMapa);
            }
            finally { _semaphore.Release(); }

            return monstruoMapa;
        }

        public async Task<List<MonstruoMapaDTO>> ObtenerTodosLosMonstruosDeTodosLosMapas()
        {
            await _semaphore.WaitAsync();

            List<MonstruoMapaDTO> monstruosMapasFinales = new();

            try
            { 
                List<IMonstruoMapa> monstruosMapas = await _monstruoMapaRepo.ObtenerTodosLosMonstruosDeTodosLosMapas(); 

                foreach(var monstruoMapa in monstruosMapas)
                {
                    monstruosMapasFinales.Add(new MonstruoMapaDTO(monstruoMapa));
                }
            }
            finally { _semaphore.Release(); }

            return monstruosMapasFinales;
        }

        public async Task<List<MonstruoMapaDTO>> ObtenerTodosLosMonstruosDeUnMapa(short referenciaMapa)
        {
            await _semaphore.WaitAsync();

            List<MonstruoMapaDTO> monstruosMapasFinales = new();

            try
            {
                List<IMonstruoMapa> monstruosMapas = await _monstruoMapaRepo.ObtenerTodosLosMonstruosDeUnMapa(referenciaMapa);

                foreach (var monstruoMapa in monstruosMapas)
                {
                    monstruosMapasFinales.Add(new MonstruoMapaDTO(monstruoMapa));
                }
            }
            finally { _semaphore.Release(); }

            return monstruosMapasFinales;
        }
    }
}