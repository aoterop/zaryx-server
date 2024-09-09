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
    internal class ImplHabilidadBasicaGuerreroRelacionDao : HabilidadBasicaGuerreroRelacionDao
    {
        private readonly string _cadenaDeConexion;

        public ImplHabilidadBasicaGuerreroRelacionDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<IHabilidadBasicaGuerreroRelacion> ObtenerHabilidadBasicaGuerreroRelacionPorId(int idHabilidadGuerrero)
        {
            IHabilidadBasicaGuerreroRelacion habilidadGuerrero = new HabilidadBasicaGuerreroRelacion();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasGuerreros WHERE idHabilidadGuerrero = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidadGuerrero);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        habilidadGuerrero.IdHabilidadGuerrero = reader.GetInt32(reader.GetOrdinal("idHabilidadGuerrero"));
                        habilidadGuerrero.RefGuerrero = reader.GetInt64(reader.GetOrdinal("refGuerrero"));
                        habilidadGuerrero.HabilidadAprendida = reader.GetInt16(reader.GetOrdinal("habilidadAprendida"));
                    }
                }
            }
            return habilidadGuerrero;
        }

        public async Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorGuerrero(long refGuerrero)
        {
            List<IHabilidadBasicaGuerreroRelacion> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasGuerreros WHERE refGuerrero = @rg";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@rg", refGuerrero);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaGuerreroRelacion habilidad = new HabilidadBasicaGuerreroRelacion();

                        habilidad.IdHabilidadGuerrero = reader.GetInt32(reader.GetOrdinal("idHabilidadGuerrero"));
                        habilidad.RefGuerrero = reader.GetInt64(reader.GetOrdinal("refGuerrero"));
                        habilidad.HabilidadAprendida = reader.GetInt16(reader.GetOrdinal("habilidadAprendida"));

                        habilidades.Add(habilidad);
                    }
                }
            }
            return habilidades;
        }

        public async Task<List<IHabilidadBasicaGuerreroRelacion>> ObtenerHabilidadBasicaGuerreroRelacionPorHabilidad(short habilidadAprendida)
        {
            List<IHabilidadBasicaGuerreroRelacion> habilidades = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM habilidadesBasicasGuerreros WHERE habilidadAprendida = @ha";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ha", habilidadAprendida);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        IHabilidadBasicaGuerreroRelacion habilidad = new HabilidadBasicaGuerreroRelacion();

                        habilidad.IdHabilidadGuerrero = reader.GetInt32(reader.GetOrdinal("idHabilidadGuerrero"));
                        habilidad.RefGuerrero = reader.GetInt64(reader.GetOrdinal("refGuerrero"));
                        habilidad.HabilidadAprendida = reader.GetInt16(reader.GetOrdinal("habilidadAprendida"));

                        habilidades.Add(habilidad);
                    }
                }
            }
            return habilidades;
        }

        public async Task<bool> CrearHabilidadBasicaGuerreroRelacion(long refGuerrero, short habilidadAprendida)
        {
            bool creado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO habilidadesBasicasGuerreros (refGuerrero, habilidadAprendida) VALUES (@guerrero, @habilidad)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@guerrero", refGuerrero);
                command.Parameters.AddWithValue("@habilidad", habilidadAprendida);


                try
                {
                    int insertado = await command.ExecuteNonQueryAsync();
                    if (insertado > 0) { creado = true; }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar la habilidad " + habilidadAprendida.ToString() + " para el guerrero " + refGuerrero.ToString() + " " +  ex.Message);
                }
            }

            return creado;
        }

        public async Task<bool> EliminarHabilidadBasicaGuerreroRelacion(int idHabilidadGuerrero)
        {
            bool eliminado = false;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM habilidadesBasicasGuerreros WHERE idHabilidadGuerrero = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idHabilidadGuerrero);

                try
                {
                    int eliminados = await command.ExecuteNonQueryAsync();
                    if (eliminados > 0) { eliminado = true; }
                }
                catch
                {
                    Console.WriteLine("No se pudo eliminar la habilidad-guerrero:  [id = " + idHabilidadGuerrero.ToString() + "]");
                }
            }

            return eliminado;
        }
    }
}