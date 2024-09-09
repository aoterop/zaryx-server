using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemEquipoOfensivoDao : ItemEquipoOfensivoDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemEquipoOfensivoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemEquipoOfensivo> ObtenerItemPorId(short idItem)
        {
            IItemEquipoOfensivo item = new ItemEquipoOfensivo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsEquipo ie INNER JOIN itemsEquipoOfensivo ieo ON ie.idItem = ieo.idItem INNER JOIN items i ON i.idItem = ie.idItem WHERE i.idItem = @id";
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
                        item.RatioCritico = reader.GetInt16(reader.GetOrdinal("ratioCritico"));
                        item.AtaqueCritico = reader.GetInt16(reader.GetOrdinal("ataqueCritico"));
                        item.AtaqueMin = reader.GetInt16(reader.GetOrdinal("ataqueMin"));
                        item.AtaqueMax = reader.GetInt16(reader.GetOrdinal("ataqueMax"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IItemEquipoOfensivo>> ObtenerTodosLosItems()
        {
            List<IItemEquipoOfensivo> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsEquipo ie INNER JOIN itemsEquipoOfensivo ieo ON ie.idItem = ieo.idItem INNER JOIN items i ON i.idItem = ie.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemEquipoOfensivo item = new ItemEquipoOfensivo();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        item.ClasePermitida = reader.GetByte(reader.GetOrdinal("clasePermitida"));
                        item.RatioCritico = reader.GetInt16(reader.GetOrdinal("ratioCritico"));
                        item.AtaqueCritico = reader.GetInt16(reader.GetOrdinal("ataqueCritico"));
                        item.AtaqueMin = reader.GetInt16(reader.GetOrdinal("ataqueMin"));
                        item.AtaqueMax = reader.GetInt16(reader.GetOrdinal("ataqueMax"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}