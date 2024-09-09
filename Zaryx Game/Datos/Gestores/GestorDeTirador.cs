using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_DAO.Interfaces;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeTirador
    {
        private readonly ITiradorRepository _tiradorRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeTirador(GestorDeRepos gestorDeRepos)
        {
            _tiradorRepo = gestorDeRepos.TiradorRepo;
        }

        public async Task<bool> CrearTirador(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try { creado = await _tiradorRepo.CrearTirador(cuentaAsociada, nombrePersonaje, peinado, aspectoFacial); }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarTirador(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _tiradorRepo.EliminarTirador(idPersonaje); }
            finally { _semaphore.Release(); }

            return eliminado;
        }

        public async Task<bool> ActualizarTirador(ITirador tirador)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _tiradorRepo.ActualizarTirador(tirador); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<TiradorDTO?> ObtenerTiradorPorId(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            TiradorDTO? tirador = null;

            try
            {
                ITirador? iTirador = await _tiradorRepo.ObtenerTiradorPorId(idPersonaje);
                if (iTirador != null) { tirador = new TiradorDTO(iTirador); } 
            }
            finally { _semaphore.Release(); }

            return tirador;
        }

        public async Task<TiradorDTO?> ObtenerTiradorPorNombre(string nombrePersonaje)
        {
            await _semaphore.WaitAsync();

            TiradorDTO? tirador = null;

            try
            {
                ITirador? iTirador = await _tiradorRepo.ObtenerTiradorPorNombre(nombrePersonaje);
                if (iTirador != null) { tirador = new TiradorDTO(iTirador); }
            }
            finally { _semaphore.Release(); }

            return tirador;
        }

        public async Task<List<TiradorDTO>> ObtenerTiradoresPorCuenta(long cuentaAsociada)
        {
            await _semaphore.WaitAsync();

            List<TiradorDTO> tiradoresFinales = new();

            try 
            { 
                List<ITirador> tiradores = await _tiradorRepo.ObtenerTiradoresPorCuenta(cuentaAsociada);

                foreach(var tirador in tiradores)
                {
                    tiradoresFinales.Add(new TiradorDTO(tirador));
                }
            }
            finally { _semaphore.Release(); }

            return tiradoresFinales;
        }

        public ITirador CrearTirador()
        {
            return _tiradorRepo.CrearTirador();
        }
    }
}