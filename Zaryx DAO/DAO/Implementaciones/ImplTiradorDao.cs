using System.Data.SqlClient;
using Zaryx_DAO.DAO.Interfaces;
using Zaryx_DAO.Entidades;
using Zaryx_DAO.Interfaces;

namespace Zaryx_DAO.Implementaciones
{
    internal class ImplTiradorDao : TiradorDao
    {
        private readonly string _cadenaDeConexion;
        public ImplTiradorDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<bool> CrearTirador(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            bool creado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO tiradores (idPersonaje, cuentaAsociada, nombrePersonaje, peinado, aspectoFacial, esAdmin, tiempoJugado, ultimoHp, ultimoMp, monedas," +
                    "nivelPersonaje, ultimoMapa, ultimoMapaX, ultimoMapaY, experienciaPersonaje, estaSilenciado) VALUES (-1, @cuenta, @nombre, @peinado, @aspectoFacial," +
                    "0, 0, 1500, 1000, 500000, 1, 0, 50, 50, 0, 0)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cuenta", cuentaAsociada);
                command.Parameters.AddWithValue("@nombre", nombrePersonaje);
                command.Parameters.AddWithValue("@peinado", peinado);
                command.Parameters.AddWithValue("@aspectoFacial", aspectoFacial);

                try
                {
                    int insertado = await command.ExecuteNonQueryAsync();

                    if (insertado > 0) { creado = true; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar el tirador: " + ex.Message);
                }
            }

            return creado;
        }

        public async Task<bool> EliminarTirador(long idPersonaje)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM tiradores WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idPersonaje);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar al tirador:  [id = " + idPersonaje.ToString() + "]");
                }
            }

            return eliminado;
        }

        public async Task<bool> ActualizarTirador(ITirador tirador)
        {
            bool actualizado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "UPDATE tiradores SET cuentaAsociada = @cuenta, nombrePersonaje = @nombre, peinado = @peinado," +
                    "aspectoFacial = @aspectoFacial, esAdmin = @esAdmin, tiempoJugado = @tiempo, ultimoHp = @hp, ultimoMp = @mp, " +
                    "monedas = @monedas, nivelPersonaje = @nivel, ultimoMapa = @mapa, ultimoMapaX = @x, ultimoMapaY = @y," +
                    "experienciaPersonaje = @exp, estaSilenciado = @silenciado WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", tirador.IdPersonaje);
                command.Parameters.AddWithValue("@cuenta", tirador.CuentaAsociada);
                command.Parameters.AddWithValue("@nombre", tirador.NombrePersonaje);
                command.Parameters.AddWithValue("@peinado", tirador.Peinado);
                command.Parameters.AddWithValue("@aspectoFacial", tirador.AspectoFacial);
                command.Parameters.AddWithValue("@esAdmin", tirador.EsAdmin);
                command.Parameters.AddWithValue("@tiempo", tirador.TiempoJugado);
                command.Parameters.AddWithValue("@hp", tirador.UltimoHp);
                command.Parameters.AddWithValue("@mp", tirador.UltimoMp);
                command.Parameters.AddWithValue("@monedas", tirador.Monedas);
                command.Parameters.AddWithValue("@nivel", tirador.NivelPersonaje);
                command.Parameters.AddWithValue("@mapa", tirador.UltimoMapa);
                command.Parameters.AddWithValue("@x", tirador.UltimoMapaX);
                command.Parameters.AddWithValue("@y", tirador.UltimoMapaY);
                command.Parameters.AddWithValue("@exp", tirador.ExperienciaPersonaje);
                command.Parameters.AddWithValue("@silenciado", tirador.EstaSilenciado);

                try
                {
                    int actualizados = await command.ExecuteNonQueryAsync();
                    if (actualizados > 0) { actualizado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo actualizar el tirador:  [id = " + tirador.IdPersonaje.ToString() + "]");
                }
            }

            return actualizado;
        }

        public async Task<ITirador?> ObtenerTiradorPorId(long idPersonaje)
        {
            ITirador? tirador = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiradores WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idPersonaje);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        tirador = new Tirador();
                        tirador.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        tirador.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        tirador.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        tirador.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        tirador.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        tirador.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        tirador.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        tirador.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        tirador.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        tirador.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        tirador.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        tirador.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        tirador.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        tirador.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        tirador.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        tirador.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));
                    }
                }
            }
            return tirador;
        }

        public async Task<ITirador?> ObtenerTiradorPorNombre(string nombrePersonaje)
        {
            ITirador? tirador = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiradores WHERE nombrePersonaje COLLATE SQL_Latin1_General_CP1_CS_AS = @np";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@np", nombrePersonaje);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        tirador = new Tirador();
                        tirador.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        tirador.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        tirador.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        tirador.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        tirador.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        tirador.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        tirador.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        tirador.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        tirador.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        tirador.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        tirador.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        tirador.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        tirador.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        tirador.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        tirador.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        tirador.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));
                    }
                }
            }
            return tirador;
        }

        public async Task<List<ITirador>> ObtenerTiradoresPorCuenta(long cuentaAsociada)
        {
            List<ITirador> tiradores = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM tiradores WHERE cuentaAsociada = @ca";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ca", cuentaAsociada);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ITirador tirador = new Tirador();

                        tirador.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        tirador.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        tirador.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        tirador.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        tirador.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        tirador.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        tirador.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        tirador.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        tirador.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        tirador.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        tirador.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        tirador.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        tirador.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        tirador.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        tirador.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        tirador.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));

                        tiradores.Add(tirador);
                    }
                }
            }
            return tiradores;
        }
    }
}