using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemEquipoDao : ItemEquipoDao<IItemEquipo>
    {
        private readonly string _cadenaDeConexion;

        public ImplItemEquipoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemEquipo> ObtenerItemPorId(short idItem)
        {
            IItemEquipo item = new ItemEquipo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsEquipo iq ON i.idItem = iq.idItem WHERE iq.idItem = @id";
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
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        item.ClasePermitida = reader.GetByte(reader.GetOrdinal("clasePermitida"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IItemEquipo>> ObtenerTodosLosItems()
        {
            List<IItemEquipo> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN itemsEquipo iq ON i.idItem = iq.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemEquipo item = new ItemEquipo();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        item.ClasePermitida = reader.GetByte(reader.GetOrdinal("clasePermitida"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}