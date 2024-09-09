using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplMapaDao : MapaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplMapaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IMapa> ObtenerMapaPorId(short idMapa)
        {
            IMapa mapa = new Mapa();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM mapas WHERE idMapa = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idMapa);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        mapa.IdMapa = reader.GetInt16(reader.GetOrdinal("idMapa"));
                        mapa.NombreMapa = reader.GetString(reader.GetOrdinal("nombreMapa"));
                        mapa.PermiteJcJ = reader.GetBoolean(reader.GetOrdinal("permiteJcJ"));
                    }
                }
            }
            return mapa;
        }

        public async Task<List<IMapa>> ObtenerTodosLosMapas()
        {
            List<IMapa> mapas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM mapas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IMapa mapa = new Mapa();

                        mapa.IdMapa = reader.GetInt16(reader.GetOrdinal("idMapa"));
                        mapa.NombreMapa = reader.GetString(reader.GetOrdinal("nombreMapa"));
                        mapa.PermiteJcJ = reader.GetBoolean(reader.GetOrdinal("permiteJcJ"));

                        mapas.Add(mapa);
                    }
                }
            }
            return mapas;
        }
    }
}