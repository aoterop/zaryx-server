using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplItemConsumoDao : ItemConsumoDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemConsumoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemConsumo> ObtenerItemPorId(short idItem)
        {
            IItemConsumo item = new ItemConsumo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsConsumo ic ON i.idItem = ic.idItem WHERE ic.idItem = @id";
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
                        item.CuraHp = reader.GetInt16(reader.GetOrdinal("curaHp"));
                        item.CuraMp = reader.GetInt16(reader.GetOrdinal("curaMp"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IItemConsumo>> ObtenerTodosLosItems()
        {
            List<IItemConsumo> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsConsumo ic ON i.idItem = ic.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemConsumo item = new ItemConsumo();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.CuraHp = reader.GetInt16(reader.GetOrdinal("curaHp"));
                        item.CuraMp = reader.GetInt16(reader.GetOrdinal("curaMp"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}