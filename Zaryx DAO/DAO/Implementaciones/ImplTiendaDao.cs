using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplTiendaDao : TiendaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplTiendaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<ITienda> ObtenerTiendaPorId(int idTienda)
        {
            ITienda tienda = new Tienda();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiendas WHERE idTienda = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idTienda);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        tienda.IdTienda = reader.GetInt32(reader.GetOrdinal("idTienda"));
                        tienda.NombreTienda = reader.GetString(reader.GetOrdinal("nombreTienda"));
                        tienda.RatioCompra = reader.GetByte(reader.GetOrdinal("ratioCompra"));
                        tienda.NombreNpc = reader.GetString(reader.GetOrdinal("nombreNpc"));
                        tienda.OrientacionNpc = reader.GetByte(reader.GetOrdinal("orientacionNpc"));
                        tienda.TiendaX = reader.GetInt16(reader.GetOrdinal("tiendaX"));
                        tienda.TiendaY = reader.GetInt16(reader.GetOrdinal("tiendaY"));
                        tienda.MapaTienda = reader.GetInt16(reader.GetOrdinal("mapaTienda"));
                    }
                }
            }
            return tienda;
        }

        public async Task<List<ITienda>> ObtenerTodasLasTiendas()
        {
            List<ITienda> tiendas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiendas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ITienda tienda = new Tienda();

                        tienda.IdTienda = reader.GetInt32(reader.GetOrdinal("idTienda"));
                        tienda.NombreTienda = reader.GetString(reader.GetOrdinal("nombreTienda"));
                        tienda.RatioCompra = reader.GetByte(reader.GetOrdinal("ratioCompra"));
                        tienda.NombreNpc = reader.GetString(reader.GetOrdinal("nombreNpc"));
                        tienda.OrientacionNpc = reader.GetByte(reader.GetOrdinal("orientacionNpc"));
                        tienda.TiendaX = reader.GetInt16(reader.GetOrdinal("tiendaX"));
                        tienda.TiendaY = reader.GetInt16(reader.GetOrdinal("tiendaY"));
                        tienda.MapaTienda = reader.GetInt16(reader.GetOrdinal("mapaTienda"));

                        tiendas.Add(tienda);
                    }
                }
            }
            return tiendas;
        }

        public async Task<List<ITienda>> ObtenerTodasLasTiendasDeUnMapa(short mapaTienda)
        {
            List<ITienda> tiendas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiendas WHERE mapaTienda = @mt";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@mt", mapaTienda);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ITienda tienda = new Tienda();

                        tienda.IdTienda = reader.GetInt32(reader.GetOrdinal("idTienda"));
                        tienda.NombreTienda = reader.GetString(reader.GetOrdinal("nombreTienda"));
                        tienda.RatioCompra = reader.GetByte(reader.GetOrdinal("ratioCompra"));
                        tienda.NombreNpc = reader.GetString(reader.GetOrdinal("nombreNpc"));
                        tienda.OrientacionNpc = reader.GetByte(reader.GetOrdinal("orientacionNpc"));
                        tienda.TiendaX = reader.GetInt16(reader.GetOrdinal("tiendaX"));
                        tienda.TiendaY = reader.GetInt16(reader.GetOrdinal("tiendaY"));
                        tienda.MapaTienda = reader.GetInt16(reader.GetOrdinal("mapaTienda"));

                        tiendas.Add(tienda);
                    }
                }
            }
            return tiendas;
        }
    }
}