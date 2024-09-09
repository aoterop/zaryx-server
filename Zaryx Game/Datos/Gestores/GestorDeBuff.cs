using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeBuff
    {
        private readonly IBuffRepository _buffRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeBuff(GestorDeRepos gestorDeRepos)
        {
            _buffRepo = gestorDeRepos.BuffRepo;
        }

        public async Task<BuffDTO> ObtenerBuffPorId(short idBuff)
        {
            await _semaphore.WaitAsync();

            BuffDTO? buff = null;

            try
            {
                IBuff ibuff = await _buffRepo.ObtenerBuffPorId(idBuff);
                buff = new BuffDTO(ibuff);
            }
            finally { _semaphore.Release(); }

            return buff;
        }

        public async Task<List<BuffDTO>> ObtenerBuffs()
        {
            await _semaphore.WaitAsync();

            List<BuffDTO> buffsFinales = new List<BuffDTO>();

            try
            {
                List<IBuff> buffs = await _buffRepo.ObtenerTodosLosBuff();

                foreach (var buff in buffs)
                {
                    buffsFinales.Add(new BuffDTO(buff));
                }
            }
            finally { _semaphore.Release(); }

            return buffsFinales;
        }
    }
}