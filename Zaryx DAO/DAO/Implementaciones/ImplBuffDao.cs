using System.Data.SqlClient;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplBuffDao : BuffDao
    {
        private readonly string _cadenaDeConexion;

        public ImplBuffDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IBuff> ObtenerBuffPorId(short idBuff)
        {
            IBuff buff = new Buff();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffs WHERE idBuff = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idBuff);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                   if(reader.HasRows)
                   {
                        await reader.ReadAsync();

                        buff.IdBuff = reader.GetInt16(reader.GetOrdinal("idBuff"));
                        buff.NombreBuff = reader.GetString(reader.GetOrdinal("nombreBuff"));
                        buff.DetallesBuff = reader.IsDBNull(reader.GetOrdinal("detallesBuff")) ? (string?)null : reader.GetString(reader.GetOrdinal("detallesBuff"));
                        buff.DuracionBuff = reader.GetInt32(reader.GetOrdinal("duracionBuff"));
                        buff.AumentoVelocidad = reader.GetInt16(reader.GetOrdinal("aumentoVelocidad"));
                        buff.AumentoDefensa = reader.GetInt16(reader.GetOrdinal("aumentoAtaque"));
                        buff.AumentoAtaque = reader.GetInt16(reader.GetOrdinal("aumentoAtaque"));
                        buff.AntiCritico = reader.GetBoolean(reader.GetOrdinal("antiCritico"));
                        buff.Inmortalidad = reader.GetBoolean(reader.GetOrdinal("inmortalidad"));
                        buff.Inmovilidad = reader.GetBoolean(reader.GetOrdinal("inmovilidad"));
                        buff.Shock = reader.GetBoolean(reader.GetOrdinal("shock"));
                        buff.SiguienteBuff = reader.IsDBNull(reader.GetOrdinal("siguienteBuff")) ? (short?)null : reader.GetInt16(reader.GetOrdinal("siguienteBuff"));

                   }
                }
            }
            return buff;
        }

        public async Task<List<IBuff>> ObtenerTodosLosBuff()
        {
            List<IBuff> buffs = new List<IBuff>();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM buffs";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IBuff buff = new Buff();

                        buff.IdBuff = reader.GetInt16(reader.GetOrdinal("idBuff"));
                        buff.NombreBuff = reader.GetString(reader.GetOrdinal("nombreBuff"));
                        buff.DetallesBuff = reader.IsDBNull(reader.GetOrdinal("detallesBuff")) ? (string?)null : reader.GetString(reader.GetOrdinal("detallesBuff"));
                        buff.DuracionBuff = reader.GetInt32(reader.GetOrdinal("duracionBuff"));
                        buff.AumentoVelocidad = reader.GetInt16(reader.GetOrdinal("aumentoVelocidad"));
                        buff.AumentoDefensa = reader.GetInt16(reader.GetOrdinal("aumentoAtaque"));
                        buff.AumentoAtaque = reader.GetInt16(reader.GetOrdinal("aumentoAtaque"));
                        buff.AntiCritico = reader.GetBoolean(reader.GetOrdinal("antiCritico"));
                        buff.Inmortalidad = reader.GetBoolean(reader.GetOrdinal("inmortalidad"));
                        buff.Inmovilidad = reader.GetBoolean(reader.GetOrdinal("inmovilidad"));
                        buff.Shock = reader.GetBoolean(reader.GetOrdinal("shock"));
                        buff.SiguienteBuff = reader.IsDBNull(reader.GetOrdinal("siguienteBuff")) ? (short?)null : reader.GetInt16(reader.GetOrdinal("siguienteBuff"));
                      
                        buffs.Add(buff);
                    }
                }
            }
            return buffs;
        }
    }
}