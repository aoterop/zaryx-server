using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplHabilidadMaestriaGuerreroDao : HabilidadMaestriaGuerreroDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadMaestriaGuerreroDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidadMaestriaGuerrero> ObtenerHabilidadPorId(short idHabilidad)
        {
            IHabilidadMaestriaGuerrero habilidad = new HabilidadMaestriaGuerrero();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesMaestriaDeGuerrero hm ON h.idHabilidad = hm.idHabilidad WHERE hm.idHabilidad = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NivelMasterMin = reader.GetByte(reader.GetOrdinal("nivelMasterMin"));
                        habilidad.Maestria = reader.GetByte(reader.GetOrdinal("maestria"));
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

        public async Task<List<IHabilidadMaestriaGuerrero>> ObtenerTodasLasHabilidades()
        {
            List<IHabilidadMaestriaGuerrero> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesMaestriaDeGuerrero hm ON h.idHabilidad = hm.idHabilidad";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadMaestriaGuerrero habilidad = new HabilidadMaestriaGuerrero();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NivelMasterMin = reader.GetByte(reader.GetOrdinal("nivelMasterMin"));
                        habilidad.Maestria = reader.GetByte(reader.GetOrdinal("maestria"));
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


        public async Task<List<IHabilidadMaestriaGuerrero>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            List<IHabilidadMaestriaGuerrero> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesMaestriaDeGuerrero hm ON h.idHabilidad = hm.idHabilidad WHERE h.tipoHabilidad = @th";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@th", tipoHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadMaestriaGuerrero habilidad = new HabilidadMaestriaGuerrero();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.NivelMasterMin = reader.GetByte(reader.GetOrdinal("nivelMasterMin"));
                        habilidad.Maestria = reader.GetByte(reader.GetOrdinal("maestria"));
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