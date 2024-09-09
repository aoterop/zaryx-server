using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplHabilidadMonstruoDao : HabilidadMonstruoDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadMonstruoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidadMonstruo> ObtenerHabilidadPorId(short idHabilidad)
        {
            IHabilidadMonstruo habilidad = new HabilidadMonstruo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesDeMonstruos hm ON h.idHabilidad = hm.idHabilidad WHERE hm.idHabilidad = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.MonstruoAsignado = reader.GetInt16(reader.GetOrdinal("monstruoAsignado"));
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

        public async Task<List<IHabilidadMonstruo>> ObtenerTodasLasHabilidades()
        {
            List<IHabilidadMonstruo> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesDeMonstruos hm ON h.idHabilidad = hm.idHabilidad";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadMonstruo habilidad = new HabilidadMonstruo();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.MonstruoAsignado = reader.GetInt16(reader.GetOrdinal("monstruoAsignado"));
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


        public async Task<List<IHabilidadMonstruo>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            List<IHabilidadMonstruo> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesDeMonstruos hm ON h.idHabilidad = hm.idHabilidad WHERE h.tipoHabilidad = @th";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@th", tipoHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadMonstruo habilidad = new HabilidadMonstruo();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.MonstruoAsignado = reader.GetInt16(reader.GetOrdinal("monstruoAsignado"));
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