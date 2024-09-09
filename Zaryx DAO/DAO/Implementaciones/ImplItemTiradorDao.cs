using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemTiradorDao : ItemTiradorDao
    {
        private readonly string _cadenaDeConexion;
        public ImplItemTiradorDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<long> CrearItemTirador(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            long idItem = -1;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO itemsTiradores (propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario) OUTPUT INSERTED.idItemTirador VALUES" +
                    " (@propietario, @item, @cantidad, @nivel, @exp, @ranura)";
                SqlCommand command = new(query, connection);

                command.Parameters.AddWithValue("@propietario", propietario);
                command.Parameters.AddWithValue("@item", referenciaItem);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@nivel", nivelItem);
                command.Parameters.AddWithValue("@exp", experienciaItem);
                command.Parameters.AddWithValue("@ranura", ranuraInventario);

                try
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            idItem = reader.GetInt64(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar el item al tirador : " + propietario + " " + ex.Message);
                }
            }

            return idItem;
        }

        public async Task<bool> EliminarItemTirador(long idItemTirador)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM itemsTiradores WHERE idItemTirador = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItemTirador);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar el item de tirador:  [id = " + idItemTirador.ToString() + "]");
                }
            }

            return eliminado;
        }

        public async Task<bool> ActualizarItemTirador(IItemTirador itemTirador)
        {
            bool actualizado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "UPDATE itemsTiradores SET propietario = @propietario, referenciaItem = @item, cantidad = @cantidad, " +
                    "nivelItem = @nivel, experienciaItem = @exp, ranuraInventario = @ranura WHERE idItemTirador = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", itemTirador.IdItemTirador);
                command.Parameters.AddWithValue("@propietario", itemTirador.Propietario);
                command.Parameters.AddWithValue("@item", itemTirador.ReferenciaItem);
                command.Parameters.AddWithValue("@cantidad", itemTirador.Cantidad);
                command.Parameters.AddWithValue("@nivel", itemTirador.NivelItem);
                command.Parameters.AddWithValue("@exp", itemTirador.ExperienciaItem);
                command.Parameters.AddWithValue("@ranura", itemTirador.RanuraInventario);

                try
                {
                    int actualizados = await command.ExecuteNonQueryAsync();
                    if (actualizados > 0) { actualizado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo actualizar el item de guerrero:  [id = " + itemTirador.IdItemTirador.ToString() + "]");
                }
            }

            return actualizado;
        }

        public async Task<List<IItemTirador>> ObtenerTodosLosItemsDeTodosLosTiradores()
        {
            List<IItemTirador> itemsGuerreros = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsTiradores";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemTirador itemGuerrero = new ItemTirador();

                        itemGuerrero.IdItemTirador = reader.GetInt64(reader.GetOrdinal("idItemTirador"));
                        itemGuerrero.Propietario = reader.GetInt64(reader.GetOrdinal("propietario"));
                        itemGuerrero.ReferenciaItem = reader.GetInt16(reader.GetOrdinal("referenciaItem"));
                        itemGuerrero.Cantidad = reader.GetInt16(reader.GetOrdinal("cantidad"));
                        itemGuerrero.NivelItem = reader.GetByte(reader.GetOrdinal("nivelItem"));
                        itemGuerrero.ExperienciaItem = reader.GetInt64(reader.GetOrdinal("experienciaItem"));
                        itemGuerrero.RanuraInventario = reader.GetByte(reader.GetOrdinal("ranuraInventario"));

                        itemsGuerreros.Add(itemGuerrero);
                    }
                }
            }
            return itemsGuerreros;
        }

        public async Task<List<IItemTirador>> ObtenerTodosLosItemsDeUnTirador(long propietario)
        {
            List<IItemTirador> itemsGuerreros = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsTiradores WHERE propietario = @p";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@p", propietario);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemTirador itemGuerrero = new ItemTirador();

                        itemGuerrero.IdItemTirador = reader.GetInt64(reader.GetOrdinal("idItemTirador"));
                        itemGuerrero.Propietario = reader.GetInt64(reader.GetOrdinal("propietario"));
                        itemGuerrero.ReferenciaItem = reader.GetInt16(reader.GetOrdinal("referenciaItem"));
                        itemGuerrero.Cantidad = reader.GetInt16(reader.GetOrdinal("cantidad"));
                        itemGuerrero.NivelItem = reader.GetByte(reader.GetOrdinal("nivelItem"));
                        itemGuerrero.ExperienciaItem = reader.GetInt64(reader.GetOrdinal("experienciaItem"));
                        itemGuerrero.RanuraInventario = reader.GetByte(reader.GetOrdinal("ranuraInventario"));

                        itemsGuerreros.Add(itemGuerrero);
                    }
                }
            }
            return itemsGuerreros;
        }
    }
}