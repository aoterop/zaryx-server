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
    internal class ImplGuerreroDao : GuerreroDao
    {
        private readonly string _cadenaDeConexion;

        public ImplGuerreroDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<bool> CrearGuerrero(long cuentaAsociada, string nombrePersonaje, byte peinado, byte aspectoFacial)
        {
            bool creado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO guerreros (idPersonaje, cuentaAsociada, nombrePersonaje, peinado, aspectoFacial, esAdmin, tiempoJugado, ultimoHp, ultimoMp, monedas," +
                    "nivelPersonaje, ultimoMapa, ultimoMapaX, ultimoMapaY, experienciaPersonaje, estaSilenciado) VALUES (-1, @cuenta, @nombre, @peinado, @aspectoFacial," +
                    "0, 0, 2000, 750, 500000, 1, 0, 50, 50, 0, 0)";
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
                catch(Exception ex)
                {
                    Console.WriteLine("Error al insertar el guerrero: " + ex.Message);
                }
            }

            return creado;
        }

        public async Task<bool> EliminarGuerrero(long idPersonaje)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM guerreros WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idPersonaje);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar al guerrero:  [id = " + idPersonaje.ToString() + "]");
                }
            }

            return eliminado;
        }

        public async Task<bool> ActualizarGuerrero(IGuerrero guerrero)
        {
            bool actualizado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "UPDATE guerreros SET cuentaAsociada = @cuenta, nombrePersonaje = @nombre, peinado = @peinado," +
                    "aspectoFacial = @aspectoFacial, esAdmin = @esAdmin, tiempoJugado = @tiempo, ultimoHp = @hp, ultimoMp = @mp, " +
                    "monedas = @monedas, nivelPersonaje = @nivel, ultimoMapa = @mapa, ultimoMapaX = @x, ultimoMapaY = @y," +
                    "experienciaPersonaje = @exp, estaSilenciado = @silenciado WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", guerrero.IdPersonaje);
                command.Parameters.AddWithValue("@cuenta", guerrero.CuentaAsociada);
                command.Parameters.AddWithValue("@nombre", guerrero.NombrePersonaje);
                command.Parameters.AddWithValue("@peinado", guerrero.Peinado);
                command.Parameters.AddWithValue("@aspectoFacial", guerrero.AspectoFacial);
                command.Parameters.AddWithValue("@esAdmin", guerrero.EsAdmin);
                command.Parameters.AddWithValue("@tiempo", guerrero.TiempoJugado);
                command.Parameters.AddWithValue("@hp", guerrero.UltimoHp);
                command.Parameters.AddWithValue("@mp", guerrero.UltimoMp);
                command.Parameters.AddWithValue("@monedas", guerrero.Monedas);
                command.Parameters.AddWithValue("@nivel", guerrero.NivelPersonaje);
                command.Parameters.AddWithValue("@mapa", guerrero.UltimoMapa);
                command.Parameters.AddWithValue("@x", guerrero.UltimoMapaX);
                command.Parameters.AddWithValue("@y", guerrero.UltimoMapaY);
                command.Parameters.AddWithValue("@exp", guerrero.ExperienciaPersonaje);
                command.Parameters.AddWithValue("@silenciado", guerrero.EstaSilenciado);

                try
                {
                    int actualizados = await command.ExecuteNonQueryAsync();
                    if (actualizados > 0) { actualizado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo actualizar el guerrero:  [id = " + guerrero.IdPersonaje.ToString() + "]");
                }
            }

            return actualizado;
        }

        public async Task<IGuerrero?> ObtenerGuerreroPorId(long idPersonaje)
        {
            IGuerrero? guerrero = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM guerreros WHERE idPersonaje = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idPersonaje);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        guerrero = new Guerrero();
                        guerrero.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        guerrero.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        guerrero.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        guerrero.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        guerrero.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        guerrero.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        guerrero.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        guerrero.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        guerrero.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        guerrero.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        guerrero.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        guerrero.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        guerrero.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        guerrero.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        guerrero.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        guerrero.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));
                    }
                }
            }
            return guerrero;
        }

        public async Task<IGuerrero?> ObtenerGuerreroPorNombre(string nombrePersonaje)
        {
            IGuerrero? guerrero = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM guerreros WHERE nombrePersonaje COLLATE SQL_Latin1_General_CP1_CS_AS = @np";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@np", nombrePersonaje);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        guerrero = new Guerrero();
                        guerrero.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        guerrero.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        guerrero.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        guerrero.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        guerrero.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        guerrero.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        guerrero.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        guerrero.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        guerrero.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        guerrero.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        guerrero.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        guerrero.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        guerrero.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        guerrero.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        guerrero.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        guerrero.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));
                    }
                }
            }
            return guerrero;
        }

        public async Task<List<IGuerrero>> ObtenerGuerrerosPorCuenta(long cuentaAsociada)
        {
            List<IGuerrero> guerreros = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM guerreros WHERE cuentaAsociada = @ca";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ca", cuentaAsociada);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IGuerrero guerrero = new Guerrero();

                        guerrero.IdPersonaje = reader.GetInt64(reader.GetOrdinal("idPersonaje"));
                        guerrero.CuentaAsociada = reader.GetInt64(reader.GetOrdinal("cuentaAsociada"));
                        guerrero.NombrePersonaje = reader.GetString(reader.GetOrdinal("nombrePersonaje"));
                        guerrero.Peinado = reader.GetByte(reader.GetOrdinal("peinado"));
                        guerrero.AspectoFacial = reader.GetByte(reader.GetOrdinal("aspectoFacial"));
                        guerrero.EsAdmin = reader.GetBoolean(reader.GetOrdinal("esAdmin"));
                        guerrero.TiempoJugado = reader.GetInt32(reader.GetOrdinal("tiempoJugado"));
                        guerrero.UltimoHp = reader.GetInt32(reader.GetOrdinal("ultimoHp"));
                        guerrero.UltimoMp = reader.GetInt32(reader.GetOrdinal("ultimoMp"));
                        guerrero.Monedas = reader.GetInt64(reader.GetOrdinal("monedas"));
                        guerrero.NivelPersonaje = reader.GetByte(reader.GetOrdinal("nivelPersonaje"));
                        guerrero.UltimoMapa = reader.GetInt16(reader.GetOrdinal("ultimoMapa"));
                        guerrero.UltimoMapaX = reader.GetInt16(reader.GetOrdinal("ultimoMapaX"));
                        guerrero.UltimoMapaY = reader.GetInt16(reader.GetOrdinal("ultimoMapaY"));
                        guerrero.ExperienciaPersonaje = reader.GetInt64(reader.GetOrdinal("experienciaPersonaje"));
                        guerrero.EstaSilenciado = reader.GetBoolean(reader.GetOrdinal("estaSilenciado"));

                        guerreros.Add(guerrero);
                    }
                }
            }
            return guerreros;
        }
    }
}