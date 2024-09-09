using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeMonstruo
    {
        private readonly IMonstruoRepository _monstruoRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeMonstruo(GestorDeRepos gestorDeRepos)
        {
            _monstruoRepo = gestorDeRepos.MonstruoRepo;
        }

        public async Task<MonstruoDTO> ObtenerMonstruoPorId(short idMonstruo)
        {
            await _semaphore.WaitAsync();

            MonstruoDTO? monstruo = null;

            try 
            { 
                IMonstruo iMonstruo = await _monstruoRepo.ObtenerMonstruoPorId(idMonstruo);
                monstruo = new MonstruoDTO(iMonstruo);
            }
            finally { _semaphore.Release(); }

            return monstruo;
        }

        public async Task<List<MonstruoDTO>> ObtenerTodosLosMonstruos()
        {
            await _semaphore.WaitAsync();

            List<MonstruoDTO> monstruosFinales = new();

            try
            { 
                List<IMonstruo> monstruos = await _monstruoRepo.ObtenerTodosLosMonstruos();

                foreach(var monstruo in monstruos)
                {
                    monstruosFinales.Add(new MonstruoDTO(monstruo));
                }
            }
            finally { _semaphore.Release(); }

            return monstruosFinales;
        }
    }
}