using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplMaestriaGuerreroDao : MaestriaGuerreroDao
    {
        private readonly string _cadenaDeConexion;

        public ImplMaestriaGuerreroDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IMaestriaGuerrero> ObtenerItemPorId(short idItem)
        {
            IMaestriaGuerrero item = new MaestriaGuerrero();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN maestriasGuerrero mg ON i.idItem = mg.idItem WHERE mg.idItem = @id";
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
                        item.NivelMinimo = reader.GetByte(reader.GetOrdinal("nivelMinimo"));
                        item.NumeroMaestria = reader.GetByte(reader.GetOrdinal("numeroMaestria"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IMaestriaGuerrero>> ObtenerTodosLosItems()
        {
            List<IMaestriaGuerrero> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM items i INNER JOIN maestriasGuerrero mg ON i.idItem = mg.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IMaestriaGuerrero item = new MaestriaGuerrero();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelMinimo = reader.GetByte(reader.GetOrdinal("nivelMinimo"));
                        item.NumeroMaestria = reader.GetByte(reader.GetOrdinal("numeroMaestria"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}