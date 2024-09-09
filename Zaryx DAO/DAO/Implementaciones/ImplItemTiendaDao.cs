using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplItemTiendaDao : ItemTiendaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemTiendaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemTienda> ObtenerItemDeTiendaPorId(int idItemTienda)
        {
            IItemTienda itemTienda = new ItemTienda();

            using (SqlConnection connection = new(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsTiendas WHERE idItemTienda = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItemTienda);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        itemTienda.IdItemTienda = reader.GetInt32(reader.GetOrdinal("idItemTienda"));
                        itemTienda.PuestoDeVenta = reader.GetInt32(reader.GetOrdinal("puestoDeVenta"));
                        itemTienda.ItemOfertado = reader.GetInt16(reader.GetOrdinal("itemOfertado"));
                    }
                }
            }
            return itemTienda;
        }

        public async Task<List<IItemTienda>> ObtenerTodosLosItemsDeTodasLasTiendas()
        {
            List<IItemTienda> itemsTiendas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsTiendas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemTienda itemTienda = new ItemTienda();

                        itemTienda.IdItemTienda = reader.GetInt32(reader.GetOrdinal("idItemTienda"));
                        itemTienda.PuestoDeVenta = reader.GetInt32(reader.GetOrdinal("puestoDeVenta"));
                        itemTienda.ItemOfertado = reader.GetInt16(reader.GetOrdinal("itemOfertado"));

                        itemsTiendas.Add(itemTienda);
                    }
                }
            }
            return itemsTiendas;
        }

        public async Task<List<IItemTienda>> ObtenerTodosLosItemsDeUnaTienda(int puestoDeVenta)
        {
            List<IItemTienda> itemsTiendas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsTiendas WHERE puestoDeVenta = @pdv";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@pdv", puestoDeVenta);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemTienda itemTienda = new ItemTienda();

                        itemTienda.IdItemTienda = reader.GetInt32(reader.GetOrdinal("idItemTienda"));
                        itemTienda.PuestoDeVenta = reader.GetInt32(reader.GetOrdinal("puestoDeVenta"));
                        itemTienda.ItemOfertado = reader.GetInt16(reader.GetOrdinal("itemOfertado"));

                        itemsTiendas.Add(itemTienda);
                    }
                }
            }
            return itemsTiendas;
        }
    }
}