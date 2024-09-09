using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplMonstruoMapaDao : MonstruoMapaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplMonstruoMapaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IMonstruoMapa> ObtenerMonstruoMapaPorId(int idMonstruoMapa)
        {
            IMonstruoMapa monstruoMapa = new MonstruoMapa();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM monstruosMapas WHERE idMonstruoMapa = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idMonstruoMapa);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        monstruoMapa.IdMonstruoMapa = reader.GetInt32(reader.GetOrdinal("idMonstruoMapa"));
                        monstruoMapa.ReferenciaMapa = reader.GetInt16(reader.GetOrdinal("referenciaMapa"));
                        monstruoMapa.ReferenciaMonstruo = reader.GetInt16(reader.GetOrdinal("referenciaMonstruo"));
                        monstruoMapa.PosicionX = reader.GetInt16(reader.GetOrdinal("posicionX"));
                        monstruoMapa.PosicionY = reader.GetInt16(reader.GetOrdinal("posicionY"));
                        monstruoMapa.OrientacionMonstruo = reader.GetByte(reader.GetOrdinal("orientacionMonstruo"));
                        monstruoMapa.PuedeMoverse = reader.GetBoolean(reader.GetOrdinal("puedeMoverse"));                     
                    }
                }
            }
            return monstruoMapa;
        }

        public async Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeTodosLosMapas()
        {
            List<IMonstruoMapa> monstruosMapas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM monstruosMapas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IMonstruoMapa monstruoMapa = new MonstruoMapa();

                        monstruoMapa.IdMonstruoMapa = reader.GetInt32(reader.GetOrdinal("idMonstruoMapa"));
                        monstruoMapa.ReferenciaMapa = reader.GetInt16(reader.GetOrdinal("referenciaMapa"));
                        monstruoMapa.ReferenciaMonstruo = reader.GetInt16(reader.GetOrdinal("referenciaMonstruo"));
                        monstruoMapa.PosicionX = reader.GetInt16(reader.GetOrdinal("posicionX"));
                        monstruoMapa.PosicionY = reader.GetInt16(reader.GetOrdinal("posicionY"));
                        monstruoMapa.OrientacionMonstruo = reader.GetByte(reader.GetOrdinal("orientacionMonstruo"));
                        monstruoMapa.PuedeMoverse = reader.GetBoolean(reader.GetOrdinal("puedeMoverse"));

                        monstruosMapas.Add(monstruoMapa);
                    }
                }
            }
            return monstruosMapas;
        }

        public async Task<List<IMonstruoMapa>> ObtenerTodosLosMonstruosDeUnMapa(short referenciaMapa)
        {
            List<IMonstruoMapa> monstruosMapa = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM monstruosMapas WHERE referenciaMapa = @rm";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@rm", referenciaMapa);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IMonstruoMapa monstruoMapa = new MonstruoMapa();

                        monstruoMapa.IdMonstruoMapa = reader.GetInt32(reader.GetOrdinal("idMonstruoMapa"));
                        monstruoMapa.ReferenciaMapa = reader.GetInt16(reader.GetOrdinal("referenciaMapa"));
                        monstruoMapa.ReferenciaMonstruo = reader.GetInt16(reader.GetOrdinal("referenciaMonstruo"));
                        monstruoMapa.PosicionX = reader.GetInt16(reader.GetOrdinal("posicionX"));
                        monstruoMapa.PosicionY = reader.GetInt16(reader.GetOrdinal("posicionY"));
                        monstruoMapa.OrientacionMonstruo = reader.GetByte(reader.GetOrdinal("orientacionMonstruo"));
                        monstruoMapa.PuedeMoverse = reader.GetBoolean(reader.GetOrdinal("puedeMoverse"));

                        monstruosMapa.Add(monstruoMapa);
                    }
                }
            }
            return monstruosMapa;
        }
    }
}