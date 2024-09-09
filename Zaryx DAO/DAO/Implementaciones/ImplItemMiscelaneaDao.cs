using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemMiscelaneaDao : ItemMiscelaneaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemMiscelaneaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemMiscelanea> ObtenerItemPorId(short idItem)
        {
            IItemMiscelanea item = new ItemMiscelanea();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsMiscelanea im ON i.idItem = im.idItem WHERE im.idItem = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItem);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelReq"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IItemMiscelanea>> ObtenerTodosLosItems()
        {
            List<IItemMiscelanea> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsMiscelanea im ON i.idItem = im.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemMiscelanea item = new ItemMiscelanea();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelReq"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}