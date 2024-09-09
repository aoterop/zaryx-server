using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplHabilidadDao : HabilidadDao<IHabilidad>
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidad> ObtenerHabilidadPorId(short idHabilidad)
        {
            IHabilidad habilidad = new Habilidad();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades WHERE idHabilidad = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NombreHabilidad = reader.GetString(reader.GetOrdinal("nombreHabilidad"));
                        habilidad.DetallesHabilidad = reader.IsDBNull(reader.GetOrdinal("detallesHabilidad")) ? null : reader.GetString(reader.GetOrdinal("detallesHabilidad"));
                        habilidad.RangoAlcance = reader.GetByte(reader.GetOrdinal("rangoAlcance"));
                        habilidad.Area = reader.GetByte(reader.GetOrdinal("area"));
                        habilidad.TiempoCarga = reader.GetInt16(reader.GetOrdinal("tiempoCarga"));
                        habilidad.DuracionHabilidad = reader.GetInt16(reader.GetOrdinal("duracionHabilidad"));
                        habilidad.ConsumoMp = reader.GetInt16(reader.GetOrdinal("consumoMp"));
                        habilidad.TipoHabilidad = reader.GetByte(reader.GetOrdinal("tipoHabilidad"));
                        habilidad.DamageBase = reader.GetInt16(reader.GetOrdinal("damageBase"));
                    }
                }
            }
            return habilidad;
        }

        public async Task<List<IHabilidad>> ObtenerTodasLasHabilidades()
        {
            List<IHabilidad> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidad habilidad = new Habilidad();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NombreHabilidad = reader.GetString(reader.GetOrdinal("nombreHabilidad"));
                        habilidad.DetallesHabilidad = reader.IsDBNull(reader.GetOrdinal("detallesHabilidad")) ? null : reader.GetString(reader.GetOrdinal("detallesHabilidad"));
                        habilidad.RangoAlcance = reader.GetByte(reader.GetOrdinal("rangoAlcance"));
                        habilidad.Area = reader.GetByte(reader.GetOrdinal("area"));
                        habilidad.TiempoCarga = reader.GetInt16(reader.GetOrdinal("tiempoCarga"));
                        habilidad.DuracionHabilidad = reader.GetInt16(reader.GetOrdinal("duracionHabilidad"));
                        habilidad.ConsumoMp = reader.GetInt16(reader.GetOrdinal("consumoMp"));
                        habilidad.TipoHabilidad = reader.GetByte(reader.GetOrdinal("tipoHabilidad"));
                        habilidad.DamageBase = reader.GetInt16(reader.GetOrdinal("damageBase"));

                        habilidades.Add(habilidad);
                    }
                }
            }
            return habilidades;
        }

        public async Task<List<IHabilidad>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            List<IHabilidad> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades WHERE tipoHabilidad = @th";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@th", tipoHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidad habilidad = new Habilidad();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NombreHabilidad = reader.GetString(reader.GetOrdinal("nombreHabilidad"));
                        habilidad.DetallesHabilidad = reader.IsDBNull(reader.GetOrdinal("detallesHabilidad")) ? null : reader.GetString(reader.GetOrdinal("detallesHabilidad"));
                        habilidad.RangoAlcance = reader.GetByte(reader.GetOrdinal("rangoAlcance"));
                        habilidad.Area = reader.GetByte(reader.GetOrdinal("area"));
                        habilidad.TiempoCarga = reader.GetInt16(reader.GetOrdinal("tiempoCarga"));
                        habilidad.DuracionHabilidad = reader.GetInt16(reader.GetOrdinal("duracionHabilidad"));
                        habilidad.ConsumoMp = reader.GetInt16(reader.GetOrdinal("consumoMp"));
                        habilidad.TipoHabilidad = reader.GetByte(reader.GetOrdinal("tipoHabilidad"));
                        habilidad.DamageBase = reader.GetInt16(reader.GetOrdinal("damageBase"));

                        habilidades.Add(habilidad);
                    }
                }
            }
            return habilidades;
        }
    }
}