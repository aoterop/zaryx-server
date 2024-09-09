using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplBuffHabilidadDao : BuffHabilidadDao
    {
        private readonly string _cadenaDeConexion;

        public ImplBuffHabilidadDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IBuffHabilidad> ObtenerBuffHabilidad(int idHabilidadBuff)
        {
            IBuffHabilidad buffHabilidad = new BuffHabilidad();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffsHabilidades WHERE idHabilidadBuff = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidadBuff);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        buffHabilidad.IdHabilidadBuff = reader.GetInt32(reader.GetOrdinal("idHabilidadBuff"));
                        buffHabilidad.BuffProducido = reader.GetInt16(reader.GetOrdinal("buffProducido"));
                        buffHabilidad.HabilidadAsociada = reader.GetInt16(reader.GetOrdinal("habilidadAsociada"));
                        buffHabilidad.ProbabilidadExito = reader.GetInt32(reader.GetOrdinal("probabilidadExito"));
                    }
                }
            }
            return buffHabilidad;
        }

        public async Task<List<IBuffHabilidad>> ObtenerTodosLosBuffHabilidad()
        {
            List<IBuffHabilidad> buffsHabilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffsHabilidades";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IBuffHabilidad buffHabilidad = new BuffHabilidad();

                        buffHabilidad.IdHabilidadBuff = reader.GetInt32(reader.GetOrdinal("idHabilidadBuff"));
                        buffHabilidad.BuffProducido = reader.GetInt16(reader.GetOrdinal("buffProducido"));
                        buffHabilidad.HabilidadAsociada = reader.GetInt16(reader.GetOrdinal("habilidadAsociada"));
                        buffHabilidad.ProbabilidadExito = reader.GetInt32(reader.GetOrdinal("probabilidadExito"));
                    
                        buffsHabilidades.Add(buffHabilidad);
                    }
                }
            }
            return buffsHabilidades;
        }

        public async Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorHabilidad(short habilidadAsociada)
        {
            List<IBuffHabilidad> buffsHabilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffsHabilidades WHERE habilidadAsociada = @ha";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ha", habilidadAsociada);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IBuffHabilidad buffHabilidad = new BuffHabilidad();

                        buffHabilidad.IdHabilidadBuff = reader.GetInt32(reader.GetOrdinal("idHabilidadBuff"));
                        buffHabilidad.BuffProducido = reader.GetInt16(reader.GetOrdinal("buffProducido"));
                        buffHabilidad.HabilidadAsociada = reader.GetInt16(reader.GetOrdinal("habilidadAsociada"));
                        buffHabilidad.ProbabilidadExito = reader.GetInt32(reader.GetOrdinal("probabilidadExito"));

                        buffsHabilidades.Add(buffHabilidad);
                    }
                }
            }
            return buffsHabilidades;
        }

        public async Task<List<IBuffHabilidad>> ObtenerBuffHabilidadPorBuff(short buffProducido)
        {
            List<IBuffHabilidad> buffsHabilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffsHabilidades WHERE buffProducido = @bp";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@bp", buffProducido);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IBuffHabilidad buffHabilidad = new BuffHabilidad();

                        buffHabilidad.IdHabilidadBuff = reader.GetInt32(reader.GetOrdinal("idHabilidadBuff"));
                        buffHabilidad.BuffProducido = reader.GetInt16(reader.GetOrdinal("buffProducido"));
                        buffHabilidad.HabilidadAsociada = reader.GetInt16(reader.GetOrdinal("habilidadAsociada"));
                        buffHabilidad.ProbabilidadExito = reader.GetInt32(reader.GetOrdinal("probabilidadExito"));

                        buffsHabilidades.Add(buffHabilidad);
                    }
                }
            }
            return buffsHabilidades;
        }
    }
}