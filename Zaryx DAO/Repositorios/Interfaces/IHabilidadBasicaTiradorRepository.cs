﻿using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Interfaces
{
    public interface IHabilidadBasicaTiradorRepository : IHabilidadRepository<IHabilidadBasicaTirador>
    {
        IHabilidadBasicaTirador CrearHabilidadBasicaTirador();
    }
}