using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class BuffHabilidadRepository : IBuffHabilidadRepository
    {
        private readonly BuffHabilidadDao _dao;
        private readonly SemaphoreSlim _semaphore = new(1);

        public BuffHabilidadRepository(BuffHabilidadDao dao) { _dao = dao; }

        public async Task<IBuffHabilidad> ObtenerBuffHabilidad(int idHabilidadBuff)
        {
            await _semaphore.WaitAsync();

            IBuffHabilidad buffHabilidad = new BuffHabilidad();

            try
            {
                buffHabilidad = await _dao.ObtenerBuffHabilidad(idHabilidadBuff);
            }
            finally
            {
                _semaphore.Release();
            }

            return buffHabilidad;
        }

        public async Task<List<IBuffHabilidad>> ObtenerTodosLosBuffHabilidad()
        {
            await _semaphore.WaitAsync();

            List<IBuffHabilidad> buffsHabilidades = new();

            try
            {
                buffsHabilidades = await _dao.ObtenerTodosLosBuffHabilidad();
            }
            finally
            {
                _semaphore.Release();
            }

            return buffsHabilidades;
        }

        public async Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorHabilidad(short habilidadAsociada)
        {
            await _semaphore.WaitAsync();

            List<IBuffHabilidad> buffsHabilidades = new();

            try
            {
                buffsHabilidades = await _dao.ObtenerBuffHabilidadPorHabilidad(habilidadAsociada);
            }
            finally
            {
                _semaphore.Release();
            }

            return buffsHabilidades;
        }

        public async Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorBuff(short buffProducido)
        {
            await _semaphore.WaitAsync();

            List<IBuffHabilidad> buffsHabilidades = new();

            try
            {
                buffsHabilidades = await _dao.ObtenerBuffHabilidadPorBuff(buffProducido);
            }
            finally
            {
                _semaphore.Release();
            }

            return buffsHabilidades;
        }

        public IBuffHabilidad CrearBuffHabilidad() { return new BuffHabilidad(); }
    }
}