using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.DAO.Implementaciones
{
    internal class ImplHabilidadBasicaTiradorRelacionDao : HabilidadBasicaTiradorRelacionDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadBasicaTiradorRelacionDao(string conex)
        {
            _cadenaDeConexion = conex;
        }


        public async Task<IHabilidadBasicaTiradorRelacion> ObtenerHabilidadBasicaTiradorRelacionPorId(int idHabilidadTirador)
        {
            IHabilidadBasicaTiradorRelacion habilidadTirador = new HabilidadBasicaTiradorRelacion();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasTiradores WHERE idHabilidadTirador = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidadTirador);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidadTirador.IdHabilidadTirador = reader.GetInt32(reader.GetOrdinal("idHabilidadTirador"));
                        habilidadTirador.RefTirador = reader.GetInt64(reader.GetOrdinal("refTirador"));
                        habilidadTirador.HabilidadAdquirida = reader.GetInt16(reader.GetOrdinal("habilidadAdquirida"));
                    }
                }
            }
            return habilidadTirador;
        }

        public async Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorTirador(long refTirador)
        {
            List<IHabilidadBasicaTiradorRelacion> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasTiradores WHERE refTirador = @rt";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@rt", refTirador);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaTiradorRelacion habilidadTirador = new HabilidadBasicaTiradorRelacion();

                        habilidadTirador.IdHabilidadTirador = reader.GetInt32(reader.GetOrdinal("idHabilidadTirador"));
                        habilidadTirador.RefTirador = reader.GetInt64(reader.GetOrdinal("refTirador"));
                        habilidadTirador.HabilidadAdquirida = reader.GetInt16(reader.GetOrdinal("habilidadAdquirida"));

                        habilidades.Add(habilidadTirador);
                    }
                }
            }
            return habilidades;
        }

        public async Task<List<IHabilidadBasicaTiradorRelacion>> ObtenerHabilidadBasicaTiradorRelacionPorHabilidad(short habilidadAdquirida)
        {
            List<IHabilidadBasicaTiradorRelacion> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasTiradores WHERE habilidadAdquirida = @ha";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ha", habilidadAdquirida);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaTiradorRelacion habilidadTirador = new HabilidadBasicaTiradorRelacion();

                        habilidadTirador.IdHabilidadTirador = reader.GetInt32(reader.GetOrdinal("idHabilidadTirador"));
                        habilidadTirador.RefTirador = reader.GetInt64(reader.GetOrdinal("refTirador"));
                        habilidadTirador.HabilidadAdquirida = reader.GetInt16(reader.GetOrdinal("habilidadAdquirida"));

                        habilidades.Add(habilidadTirador);
                    }
                }
            }
            return habilidades;
        }

        public async Task<bool> CrearHabilidadBasicaTiradorRelacion(long refTirador, short habilidadAdquirida)
        {
            bool creado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO habilidadesBasicasTiradores (refTirador, habilidadAdquirida) VALUES (@tirador, @habilidad)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tirador", refTirador);
                command.Parameters.AddWithValue("@habilidad", habilidadAdquirida);


                try
                {
                    int insertado = await command.ExecuteNonQueryAsync();
                    if (insertado > 0) { creado = true; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar la habilidad " + habilidadAdquirida.ToString() + " para el tirador " + refTirador.ToString() + " " + ex.Message);
                }
            }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaTiradorRelacion(int idHabilidadTirador)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM habilidadesBasicasTiradores WHERE idHabilidadTirador = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidadTirador);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar la habilidad-tirador:  [id = " + idHabilidadTirador.ToString() + "]");
                }
            }

            return eliminado;
        }
    }
}