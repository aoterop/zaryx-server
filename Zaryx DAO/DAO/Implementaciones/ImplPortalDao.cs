using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Repositorios.Implementacioens
{
    internal class ImplPortalDao : PortalDao
    {
        private readonly string _cadenaDeConexion;
        public ImplPortalDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IPortal> ObtenerPortalPorId(int idPortal)
        {
            IPortal portal = new Portal();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM portales WHERE idPortal = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idPortal);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        portal.IdPortal = reader.GetInt32(reader.GetOrdinal("idPortal"));
                        portal.DestinoX = reader.GetInt16(reader.GetOrdinal("destinoX"));
                        portal.DestinoY = reader.GetInt16(reader.GetOrdinal("destinoY"));
                        portal.OrigenX = reader.GetInt16(reader.GetOrdinal("origenX"));
                        portal.OrigenY = reader.GetInt16(reader.GetOrdinal("origenY"));
                        portal.MapaDestino = reader.GetInt16(reader.GetOrdinal("mapaDestino"));
                        portal.MapaOrigen = reader.GetInt16(reader.GetOrdinal("mapaOrigen"));
                        portal.AparienciaPortal = reader.GetByte(reader.GetOrdinal("aparienciaPortal"));
                    }
                }
            }
            return portal;
        }

        public async Task<List<IPortal>> ObtenerTodosLosPortales()
        {
            List<IPortal> portales = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM portales";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IPortal portal = new Portal();

                        portal.IdPortal = reader.GetInt32(reader.GetOrdinal("idPortal"));
                        portal.DestinoX = reader.GetInt16(reader.GetOrdinal("destinoX"));
                        portal.DestinoY = reader.GetInt16(reader.GetOrdinal("destinoY"));
                        portal.OrigenX = reader.GetInt16(reader.GetOrdinal("origenX"));
                        portal.OrigenY = reader.GetInt16(reader.GetOrdinal("origenY"));
                        portal.MapaDestino = reader.GetInt16(reader.GetOrdinal("mapaDestino"));
                        portal.MapaOrigen = reader.GetInt16(reader.GetOrdinal("mapaOrigen"));
                        portal.AparienciaPortal = reader.GetByte(reader.GetOrdinal("aparienciaPortal"));

                        portales.Add(portal);
                    }
                }
            }

            return portales;
        }

        public async Task<List<IPortal>> ObtenerTodosLosPortalesDeUnMapa(short mapaOrigen)
        {
            List<IPortal> portales = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM portales WHERE mapaOrigen = @mo";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@mo", mapaOrigen);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IPortal portal = new Portal();

                        portal.IdPortal = reader.GetInt32(reader.GetOrdinal("idPortal"));
                        portal.DestinoX = reader.GetInt16(reader.GetOrdinal("destinoX"));
                        portal.DestinoY = reader.GetInt16(reader.GetOrdinal("destinoY"));
                        portal.OrigenX = reader.GetInt16(reader.GetOrdinal("origenX"));
                        portal.OrigenY = reader.GetInt16(reader.GetOrdinal("origenY"));
                        portal.MapaDestino = reader.GetInt16(reader.GetOrdinal("mapaDestino"));
                        portal.MapaOrigen = reader.GetInt16(reader.GetOrdinal("mapaOrigen"));
                        portal.AparienciaPortal = reader.GetByte(reader.GetOrdinal("aparienciaPortal"));

                        portales.Add(portal);
                    }
                }
            }
            return portales;
        }
    }
}