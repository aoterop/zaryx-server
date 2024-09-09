using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeGuerrero
    {
        private readonly IGuerreroRepository _guerreroRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeGuerrero(GestorDeRepos gestorDeRepos)
        {
            _guerreroRepo = gestorDeRepos.GuerreroRepo;
        }

        public async Task<bool> CrearGuerrero(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            await _semaphore.WaitAsync();

            bool creado = false;

            try
            { 
                creado = await _guerreroRepo.CrearGuerrero(cuentaAsociada, nombrePersonaje, peinado, aspectoFacial); 
            }
            finally { _semaphore.Release(); }

            return creado;
        }

        public async Task<bool> EliminarGuerrero(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            bool eliminado = false;

            try { eliminado = await _guerreroRepo.EliminarGuerrero(idPersonaje); }
            finally { _semaphore.Release(); }

            return eliminado;
        }


        public async Task<bool> ActualizarGuerrero(IGuerrero guerrero)
        {
            await _semaphore.WaitAsync();

            bool actualizado = false;

            try { actualizado = await _guerreroRepo.ActualizarGuerrero(guerrero); }
            finally { _semaphore.Release(); }

            return actualizado;
        }

        public async Task<GuerreroDTO?> ObtenerGuerreroPorId(long idPersonaje)
        {
            await _semaphore.WaitAsync();

            GuerreroDTO? guerrero = null;

            try 
            {
                IGuerrero? iGuerrero = await _guerreroRepo.ObtenerGuerreroPorId(idPersonaje);
                if (iGuerrero != null) { guerrero = new GuerreroDTO(iGuerrero); }
            }
            finally { _semaphore.Release(); }

            return guerrero;
        }

        public async Task<GuerreroDTO?> ObtenerGuerreroPorNombre(string nombrePersonaje)
        {
            await _semaphore.WaitAsync();

            GuerreroDTO? guerrero = null;

            try 
            { 
                IGuerrero? iGuerrero = await _guerreroRepo.ObtenerGuerreroPorNombre(nombrePersonaje);
                if (iGuerrero != null) { guerrero = new GuerreroDTO(iGuerrero); }
            }
            finally { _semaphore.Release(); }

            return guerrero;
        }

        public async Task<List<GuerreroDTO>> ObtenerGuerrerosPorCuenta(long cuentaAsociada)
        {
            await _semaphore.WaitAsync();

            List<GuerreroDTO> guerrerosFinales = new();

            try 
            {
                List<IGuerrero> guerreros = await _guerreroRepo.ObtenerGuerrerosPorCuenta(cuentaAsociada);

                foreach(var guerrero in guerreros)
                {
                    guerrerosFinales.Add(new GuerreroDTO(guerrero));
                }
            }
            finally { _semaphore.Release(); }

            return guerrerosFinales;
        }

        public IGuerrero CrearGuerrero()
        {
            return _guerreroRepo.CrearGuerrero();
        }
    }
}