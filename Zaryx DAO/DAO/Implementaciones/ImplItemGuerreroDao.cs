using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplItemGuerreroDao : ItemGuerreroDao
    {
        private readonly string _cadenaDeConexion;
        public ImplItemGuerreroDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<long> CrearItemGuerrero(long propietario, short referenciaItem, short cantidad, byte nivelItem, long experienciaItem, byte ranuraInventario)
        {
            long idItem = -1;

            using (SqlConnection connection = new(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO itemsGuerreros (propietario, referenciaItem, cantidad, nivelItem, experienciaItem, ranuraInventario) OUTPUT INSERTED.idItemGuerrero VALUES" +
                    " (@propietario, @item, @cantidad, @nivel, @exp, @ranura)";
                SqlCommand command = new SqlCommand(query, connection);

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
                    Console.WriteLine("Error al insertar el item al guerrero : " + propietario + " " + ex.Message);
                }
            }

            return idItem;
        }

        public async Task<bool> EliminarItemGuerrero(long idItemGuerrero)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM itemsGuerreros WHERE idItemGuerrero = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idItemGuerrero);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar el item de guerrero:  [id = " + idItemGuerrero.ToString() + "]");
                }
            }

            return eliminado;
        }


        public async Task<bool> ActualizarItemGuerrero(IItemGuerrero itemGuerrero)
        {
            bool actualizado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "UPDATE itemsGuerreros SET propietario = @propietario, referenciaItem = @item, cantidad = @cantidad, " +
                    "nivelItem = @nivel, experienciaItem = @exp, ranuraInventario = @ranura WHERE idItemGuerrero = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", itemGuerrero.IdItemGuerrero);
                command.Parameters.AddWithValue("@propietario", itemGuerrero.Propietario);
                command.Parameters.AddWithValue("@item", itemGuerrero.ReferenciaItem);
                command.Parameters.AddWithValue("@cantidad", itemGuerrero.Cantidad);            
                command.Parameters.AddWithValue("@nivel", itemGuerrero.NivelItem);
                command.Parameters.AddWithValue("@exp", itemGuerrero.ExperienciaItem);
                command.Parameters.AddWithValue("@ranura", itemGuerrero.RanuraInventario);

                try
                {
                    int actualizados = await command.ExecuteNonQueryAsync();
                    if (actualizados > 0) { actualizado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo actualizar el item de guerrero:  [id = " + itemGuerrero.IdItemGuerrero.ToString() + "]");
                }
            }

            return actualizado;
        }


        public async Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeTodosLosGuerreros()
        {
            List<IItemGuerrero> itemsGuerreros = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsGuerreros";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ItemGuerrero itemGuerrero = new ItemGuerrero();

                        itemGuerrero.IdItemGuerrero = reader.GetInt64(reader.GetOrdinal("idItemGuerrero"));
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

        public async Task<List<IItemGuerrero>> ObtenerTodosLosItemsDeUnGuerrero(long propietario)
        {
            List<IItemGuerrero> itemsGuerreros = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM itemsGuerreros WHERE propietario = @p";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@p", propietario);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IItemGuerrero itemGuerrero = new ItemGuerrero();

                        itemGuerrero.IdItemGuerrero = reader.GetInt64(reader.GetOrdinal("idItemGuerrero"));
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