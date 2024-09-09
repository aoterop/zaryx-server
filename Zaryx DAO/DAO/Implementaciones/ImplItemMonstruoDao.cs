using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemMonstruoDao : ItemMonstruoDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemMonstruoDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IItemMonstruo> ObtenerItemMonstruoPorId(short idItemMonstruo)
        {
            IItemMonstruo itemMonstruo = new ItemMonstruo();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsMonstruos WHERE idItemMonstruo = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItemMonstruo);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        itemMonstruo.IdItemMonstruo = reader.GetInt16(reader.GetOrdinal("idItemMonstruo"));
                        itemMonstruo.CantidadArrojada = reader.GetInt16(reader.GetOrdinal("cantidadArrojada"));
                        itemMonstruo.ProbabilidadArrojar = reader.GetInt32(reader.GetOrdinal("probabilidadArrojar"));
                        itemMonstruo.ItemArrojable = reader.GetInt16(reader.GetOrdinal("itemArrojable"));
                        itemMonstruo.MonstruoArrojador = reader.GetInt16(reader.GetOrdinal("monstruoArrojador"));
                    }
                }
            }
            return itemMonstruo;
        }

        public async Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeTodosLosMonstruos()
        {
            List<IItemMonstruo> itemsMonstruos = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsMonstruos";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemMonstruo itemMonstruo = new ItemMonstruo();

                        itemMonstruo.IdItemMonstruo = reader.GetInt16(reader.GetOrdinal("idItemMonstruo"));
                        itemMonstruo.CantidadArrojada = reader.GetInt16(reader.GetOrdinal("cantidadArrojada"));
                        itemMonstruo.ProbabilidadArrojar = reader.GetInt32(reader.GetOrdinal("probabilidadArrojar"));
                        itemMonstruo.ItemArrojable = reader.GetInt16(reader.GetOrdinal("itemArrojable"));
                        itemMonstruo.MonstruoArrojador = reader.GetInt16(reader.GetOrdinal("monstruoArrojador"));

                        itemsMonstruos.Add(itemMonstruo);
                    }
                }
            }
            return itemsMonstruos;
        }

        public async Task<List<IItemMonstruo>> ObtenerTodosLosItemsDeUnMonstruo(short monstruoArrojador)
        {
            List<IItemMonstruo> itemsMonstruo = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsMonstruos WHERE monstruoArrojador = @ma";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ma", monstruoArrojador);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemMonstruo itemMonstruo = new ItemMonstruo();

                        itemMonstruo.IdItemMonstruo = reader.GetInt16(reader.GetOrdinal("idItemMonstruo"));
                        itemMonstruo.CantidadArrojada = reader.GetInt16(reader.GetOrdinal("cantidadArrojada"));
                        itemMonstruo.ProbabilidadArrojar = reader.GetInt32(reader.GetOrdinal("probabilidadArrojar"));
                        itemMonstruo.ItemArrojable = reader.GetInt16(reader.GetOrdinal("itemArrojable"));
                        itemMonstruo.MonstruoArrojador = reader.GetInt16(reader.GetOrdinal("monstruoArrojador"));

                        itemsMonstruo.Add(itemMonstruo);
                    }
                }
            }
            return itemsMonstruo;
        }
    }
}