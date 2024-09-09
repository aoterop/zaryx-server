using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplMonstruoDao : MonstruoDao
    {
        private readonly string _cadenaDeConexion;
        public ImplMonstruoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IMonstruo> ObtenerMonstruoPorId(short idMonstruo)
        {
            IMonstruo monstruo = new Monstruo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM monstruos WHERE idMonstruo = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idMonstruo);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        monstruo.IdMonstruo = reader.GetInt16(reader.GetOrdinal("idMonstruo"));
                        monstruo.NombreMonstruo = reader.GetString(reader.GetOrdinal("nombreMonstruo"));
                        monstruo.DetallesMonstruo = reader.IsDBNull(reader.GetOrdinal("detallesMonstruo")) ? (string?)null : reader.GetString(reader.GetOrdinal("detallesMonstruo"));
                        monstruo.TiempoReaparicion = reader.GetInt32(reader.GetOrdinal("tiempoReaparicion"));
                        monstruo.VelocidadMonstruo = reader.GetByte(reader.GetOrdinal("velocidadMonstruo"));
                        monstruo.AumentoExperiencia = reader.GetInt32(reader.GetOrdinal("aumentoExperiencia"));
                        monstruo.NivelMonstruo = reader.GetByte(reader.GetOrdinal("nivelMonstruo"));
                        monstruo.MaxHpMonstruo = reader.GetInt32(reader.GetOrdinal("maxHpMonstruo"));
                        monstruo.MaxMpMonstruo = reader.GetInt32(reader.GetOrdinal("maxMpMonstruo"));
                        monstruo.AtaqueMinMonstruo = reader.GetInt16(reader.GetOrdinal("ataqueMinMonstruo"));
                        monstruo.AtaqueMaxMonstruo = reader.GetInt16(reader.GetOrdinal("ataqueMaxMonstruo"));
                        monstruo.DefensaMonstruo = reader.GetInt16(reader.GetOrdinal("defensaMonstruo"));
                        monstruo.EsAgresivo = reader.GetBoolean(reader.GetOrdinal("esAgresivo"));
                    }
                }
            }
            return monstruo;
        }

        public async Task<List<IMonstruo>> ObtenerTodosLosMonstruos()
        {
            List<IMonstruo> monstruos = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM monstruos";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IMonstruo monstruo = new Monstruo();

                        monstruo.IdMonstruo = reader.GetInt16(reader.GetOrdinal("idMonstruo"));
                        monstruo.NombreMonstruo = reader.GetString(reader.GetOrdinal("nombreMonstruo"));
                        monstruo.DetallesMonstruo = reader.IsDBNull(reader.GetOrdinal("detallesMonstruo")) ? (string?)null : reader.GetString(reader.GetOrdinal("detallesMonstruo"));
                        monstruo.TiempoReaparicion = reader.GetInt32(reader.GetOrdinal("tiempoReaparicion"));
                        monstruo.VelocidadMonstruo = reader.GetByte(reader.GetOrdinal("velocidadMonstruo"));
                        monstruo.AumentoExperiencia = reader.GetInt32(reader.GetOrdinal("aumentoExperiencia"));
                        monstruo.NivelMonstruo = reader.GetByte(reader.GetOrdinal("nivelMonstruo"));
                        monstruo.MaxHpMonstruo = reader.GetInt32(reader.GetOrdinal("maxHpMonstruo"));
                        monstruo.MaxMpMonstruo = reader.GetInt32(reader.GetOrdinal("maxMpMonstruo"));
                        monstruo.AtaqueMinMonstruo = reader.GetInt16(reader.GetOrdinal("ataqueMinMonstruo"));
                        monstruo.AtaqueMaxMonstruo = reader.GetInt16(reader.GetOrdinal("ataqueMaxMonstruo"));
                        monstruo.DefensaMonstruo = reader.GetInt16(reader.GetOrdinal("defensaMonstruo"));
                        monstruo.EsAgresivo = reader.GetBoolean(reader.GetOrdinal("esAgresivo"));

                        monstruos.Add(monstruo);
                    }
                }
            }
            return monstruos;
        }
    }
}