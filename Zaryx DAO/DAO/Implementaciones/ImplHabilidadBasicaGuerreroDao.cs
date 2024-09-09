using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplHabilidadBasicaGuerreroDao : HabilidadBasicaGuerreroDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadBasicaGuerreroDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidadBasicaGuerrero> ObtenerHabilidadPorId(short idHabilidad)
        {
            IHabilidadBasicaGuerrero habilidadBasicaGuerrero = new HabilidadBasicaGuerrero();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasGuerrero hb ON h.idHabilidad = hb.idHabilidad WHERE hb.idHabilidad = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidadBasicaGuerrero.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidadBasicaGuerrero.RequiereObjetivo = reader.GetBoolean(reader.GetOrdinal("requiereObjetivo"));
                        habilidadBasicaGuerrero.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        habilidadBasicaGuerrero.NombreHabilidad = reader.GetString(reader.GetOrdinal("nombreHabilidad"));
                        habilidadBasicaGuerrero.DetallesHabilidad = reader.IsDBNull(reader.GetOrdinal("detallesHabilidad")) ? null : reader.GetString(reader.GetOrdinal("detallesHabilidad"));
                        habilidadBasicaGuerrero.RangoAlcance = reader.GetByte(reader.GetOrdinal("rangoAlcance"));
                        habilidadBasicaGuerrero.Area = reader.GetByte(reader.GetOrdinal("area"));
                        habilidadBasicaGuerrero.TiempoCarga = reader.GetInt16(reader.GetOrdinal("tiempoCarga"));
                        habilidadBasicaGuerrero.DuracionHabilidad = reader.GetInt16(reader.GetOrdinal("duracionHabilidad"));
                        habilidadBasicaGuerrero.ConsumoMp = reader.GetInt16(reader.GetOrdinal("consumoMp"));
                        habilidadBasicaGuerrero.TipoHabilidad = reader.GetByte(reader.GetOrdinal("tipoHabilidad"));
                        habilidadBasicaGuerrero.DamageBase = reader.GetInt16(reader.GetOrdinal("damageBase"));
                    }
                }
            }
            return habilidadBasicaGuerrero;
        }

        public async Task<List<IHabilidadBasicaGuerrero>> ObtenerTodasLasHabilidades()
        {
            List<IHabilidadBasicaGuerrero> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasGuerrero hb ON h.idHabilidad = hb.idHabilidad";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaGuerrero habilidad = new HabilidadBasicaGuerrero();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.RequiereObjetivo = reader.GetBoolean(reader.GetOrdinal("requiereObjetivo"));
                        habilidad.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
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


        public async Task<List<IHabilidadBasicaGuerrero>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            List<IHabilidadBasicaGuerrero> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasGuerrero hb ON h.idHabilidad = hb.idHabilidad WHERE h.tipoHabilidad = @th";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@th", tipoHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaGuerrero habilidad = new HabilidadBasicaGuerrero();

                        habilidad.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidad.RequiereObjetivo = reader.GetBoolean(reader.GetOrdinal("requiereObjetivo"));
                        habilidad.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
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