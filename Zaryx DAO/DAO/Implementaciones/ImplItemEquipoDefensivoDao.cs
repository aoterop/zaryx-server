using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplItemEquipoDefensivoDao : ItemEquipoDefensivoDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemEquipoDefensivoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemEquipoDefensivo> ObtenerItemPorId(short idItem)
        {
            IItemEquipoDefensivo item = new ItemEquipoDefensivo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsEquipo ie INNER JOIN itemsEquipoDefensivo ied ON ie.idItem = ied.idItem INNER JOIN items i ON i.idItem = ie.idItem WHERE i.idItem = @id";
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
                        item.TipoEquipoDefensivo = reader.GetByte(reader.GetOrdinal("tipoEquipoDefensivo"));
                        item.DefensaItem = reader.GetInt16(reader.GetOrdinal("defensaItem"));
                        item.VelocidadExtra = reader.GetByte(reader.GetOrdinal("velocidadExtra"));
                    }
                }
            }
            return item;
        }

        public async Task<List<IItemEquipoDefensivo>> ObtenerTodosLosItems()
        {
            List<IItemEquipoDefensivo> items = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsEquipo ie INNER JOIN itemsEquipoDefensivo ied ON ie.idItem = ied.idItem INNER JOIN items i ON i.idItem = ie.idItem";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemEquipoDefensivo item = new ItemEquipoDefensivo();

                        item.IdItem = reader.GetInt16(reader.GetOrdinal("idItem"));
                        item.NombreItem = reader.GetString(reader.GetOrdinal("nombreItem"));
                        item.DetallesItem = reader.IsDBNull(reader.GetOrdinal("detallesItem")) ? null : reader.GetString(reader.GetOrdinal("detallesItem"));
                        item.Precio = reader.GetInt64(reader.GetOrdinal("precio"));
                        item.EsArrojable = reader.GetBoolean(reader.GetOrdinal("esArrojable"));
                        item.NivelRequerido = reader.GetByte(reader.GetOrdinal("nivelRequerido"));
                        item.ClasePermitida = reader.GetByte(reader.GetOrdinal("clasePermitida"));
                        item.TipoEquipoDefensivo = reader.GetByte(reader.GetOrdinal("tipoEquipoDefensivo"));
                        item.DefensaItem = reader.GetInt16(reader.GetOrdinal("defensaItem"));
                        item.VelocidadExtra = reader.GetByte(reader.GetOrdinal("velocidadExtra"));

                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}