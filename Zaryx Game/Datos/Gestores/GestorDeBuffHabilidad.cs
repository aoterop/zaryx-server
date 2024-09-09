using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaryx_DAO.Interfaces;
using Zaryx_DAO.Repositorios.Interfaces;
using Zaryx_DAO;
using Zaryx_Game.Datos.Modelos;

namespace Zaryx_Game.Datos.Gestores
{
    internal class GestorDeBuffHabilidad
    {
        private readonly IBuffHabilidadRepository _buffHabilidadRepo;
        private readonly SemaphoreSlim _semaphore = new(1);

        public GestorDeBuffHabilidad(GestorDeRepos gestorDeRepos)
        {
            _buffHabilidadRepo = gestorDeRepos.BuffHabilidadRepo;
        }

        public async Task<BuffHabilidadDTO> ObtenerBuffHabilidadPorId(int idBuffHabilidad)
        {
            await _semaphore.WaitAsync();

            BuffHabilidadDTO? buffHabilidad = null;

            try
            {
                IBuffHabilidad ibuff = await _buffHabilidadRepo.ObtenerBuffHabilidad(idBuffHabilidad);
                buffHabilidad = new BuffHabilidadDTO(ibuff);
            }
            finally { _semaphore.Release(); }

            return buffHabilidad;
        }

        public async Task<List<BuffHabilidadDTO>> ObtenerBuffsHabilidad()
        {
            await _semaphore.WaitAsync();

            List<BuffHabilidadDTO> buffsHabilidadFinales = new();

            try
            {
                List<IBuffHabilidad> buffsHabilidad = await _buffHabilidadRepo.ObtenerTodosLosBuffHabilidad();

                foreach (var buffHabilidad in buffsHabilidad)
                {
                    buffsHabilidadFinales.Add(new BuffHabilidadDTO(buffHabilidad));
                }
            }
            finally { _semaphore.Release(); }

            return buffsHabilidadFinales;
        }

        public async Task<List<BuffHabilidadDTO>> ObtenerBuffHabilidadPorHabilidad(short habilidadAsociada)
        {
            await _semaphore.WaitAsync();

            List<BuffHabilidadDTO> buffsHabilidadFinales = new();

            try
            {
                List<IBuffHabilidad> buffsHabilidad = await _buffHabilidadRepo.ObtenerBuffHabilidadPorHabilidad(habilidadAsociada);

                foreach (var buffHabilidad in buffsHabilidad)
                {
                    buffsHabilidadFinales.Add(new BuffHabilidadDTO(buffHabilidad));
                }
            }
            finally { _semaphore.Release(); }

            return buffsHabilidadFinales;
        }

        public async Task<List<BuffHabilidadDTO>> ObtenerBuffHabilidadPorBuff(short buffProducido)
        {
            await _semaphore.WaitAsync();

            List<BuffHabilidadDTO> buffsHabilidadFinales = new();

            try
            {
                List<IBuffHabilidad> buffsHabilidad = await _buffHabilidadRepo.ObtenerBuffHabilidadPorBuff(buffProducido);

                foreach (var buffHabilidad in buffsHabilidad)
                {
                    buffsHabilidadFinales.Add(new BuffHabilidadDTO(buffHabilidad));
                }
            }
            finally { _semaphore.Release(); }

            return buffsHabilidadFinales;
        }
    }
}