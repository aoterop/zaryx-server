using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplHabilidadBasicaTiradorDao : HabilidadBasicaTiradorDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadBasicaTiradorDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidadBasicaTirador> ObtenerHabilidadPorId(short idHabilidad)
        {
            IHabilidadBasicaTirador habilidadBasicaTirador = new HabilidadBasicaTirador();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasTirador hb ON h.idHabilidad = hb.idHabilidad WHERE hb.idHabilidad = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidadBasicaTirador.IdHabilidad = reader.GetInt16(reader.GetOrdinal("idHabilidad"));
                        habilidadBasicaTirador.RequiereObjetivo = reader.GetBoolean(reader.GetOrdinal("requiereObjetivo"));
                        habilidadBasicaTirador.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        habilidadBasicaTirador.NombreHabilidad = reader.GetString(reader.GetOrdinal("nombreHabilidad"));
                        habilidadBasicaTirador.DetallesHabilidad = reader.IsDBNull(reader.GetOrdinal("detallesHabilidad")) ? null : reader.GetString(reader.GetOrdinal("detallesHabilidad"));
                        habilidadBasicaTirador.RangoAlcance = reader.GetByte(reader.GetOrdinal("rangoAlcance"));
                        habilidadBasicaTirador.Area = reader.GetByte(reader.GetOrdinal("area"));
                        habilidadBasicaTirador.TiempoCarga = reader.GetInt16(reader.GetOrdinal("tiempoCarga"));
                        habilidadBasicaTirador.DuracionHabilidad = reader.GetInt16(reader.GetOrdinal("duracionHabilidad"));
                        habilidadBasicaTirador.ConsumoMp = reader.GetInt16(reader.GetOrdinal("consumoMp"));
                        habilidadBasicaTirador.TipoHabilidad = reader.GetByte(reader.GetOrdinal("tipoHabilidad"));
                        habilidadBasicaTirador.DamageBase = reader.GetInt16(reader.GetOrdinal("damageBase"));
                    }
                }
            }
            return habilidadBasicaTirador;
        }

        public async Task<List<IHabilidadBasicaTirador>> ObtenerTodasLasHabilidades()
        {
            List<IHabilidadBasicaTirador> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasTirador hb ON h.idHabilidad = hb.idHabilidad";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaTirador habilidad = new HabilidadBasicaTirador();

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


        public async Task<List<IHabilidadBasicaTirador>> ObtenerHabilidadPorTipo(byte tipoHabilidad)
        {
            List<IHabilidadBasicaTirador> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidades h INNER JOIN habilidadesBasicasTirador hb ON h.idHabilidad = hb.idHabilidad WHERE h.tipoHabilidad = @th";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@th", tipoHabilidad);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaTirador habilidad = new HabilidadBasicaTirador();

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