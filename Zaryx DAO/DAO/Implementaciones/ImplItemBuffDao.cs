using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplItemBuffDao : ItemBuffDao
    {
        private readonly string _cadenaDeConexion;

        public ImplItemBuffDao(string conex)
        {
            _cadenaDeConexion = conex;
        }
        public async Task<IItemBuff> ObtenerItemBuffPorId(int idItemBuff)
        {
            IItemBuff itemBuff = new ItemBuff();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsBuffs WHERE idItemBuff = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItemBuff);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        itemBuff.IdItemBuff = reader.GetInt32(reader.GetOrdinal("idItemBuff"));
                        itemBuff.ItemGenerador = reader.GetInt16(reader.GetOrdinal("itemGenerador"));
                        itemBuff.BuffGenerador = reader.GetInt16(reader.GetOrdinal("buffGenerador"));
                        itemBuff.EsGrupal = reader.GetBoolean(reader.GetOrdinal("esGrupal"));
                    }
                }
            }
            return itemBuff;
        }

        public async Task<List<IItemBuff>> ObtenerItemsBuffPorItem(short itemGenerador)
        {
            List<IItemBuff> itemsBuffs = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsBuffs WHERE itemGenerador = @ig";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ig", itemGenerador);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemBuff itemBuff = new ItemBuff();

                        itemBuff.IdItemBuff = reader.GetInt32(reader.GetOrdinal("idItemBuff"));
                        itemBuff.ItemGenerador = reader.GetInt16(reader.GetOrdinal("itemGenerador"));
                        itemBuff.BuffGenerador = reader.GetInt16(reader.GetOrdinal("buffGenerador"));
                        itemBuff.EsGrupal = reader.GetBoolean(reader.GetOrdinal("esGrupal"));

                        itemsBuffs.Add(itemBuff);
                    }
                }
            }
            return itemsBuffs;
        }

        public async Task<List<IItemBuff>> ObtenerItemsBuffPorBuff(short buffGenerador)
        {
            List<IItemBuff> itemsBuffs = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsBuffs WHERE buffGenerador = @bg";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@bg", buffGenerador);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemBuff itemBuff = new ItemBuff();

                        itemBuff.IdItemBuff = reader.GetInt32(reader.GetOrdinal("idItemBuff"));
                        itemBuff.ItemGenerador = reader.GetInt16(reader.GetOrdinal("itemGenerador"));
                        itemBuff.BuffGenerador = reader.GetInt16(reader.GetOrdinal("buffGenerador"));
                        itemBuff.EsGrupal = reader.GetBoolean(reader.GetOrdinal("esGrupal"));

                        itemsBuffs.Add(itemBuff);
                    }
                }
            }
            return itemsBuffs;
        }

        public async Task<List<IItemBuff>> ObtenerTodosLosItemBuff()
        {
            List<IItemBuff> itemsBuffs = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsBuffs";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemBuff itemBuff = new ItemBuff();

                        itemBuff.IdItemBuff = reader.GetInt32(reader.GetOrdinal("idItemBuff"));
                        itemBuff.ItemGenerador = reader.GetInt16(reader.GetOrdinal("itemGenerador"));
                        itemBuff.BuffGenerador = reader.GetInt16(reader.GetOrdinal("buffGenerador"));
                        itemBuff.EsGrupal = reader.GetBoolean(reader.GetOrdinal("esGrupal"));

                        itemsBuffs.Add(itemBuff);
                    }
                }
            }
            return itemsBuffs;
        }
    }
}