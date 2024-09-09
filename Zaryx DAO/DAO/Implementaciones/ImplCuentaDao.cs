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
    internal class ImplCuentaDao : CuentaDao
    {
        private readonly string _cadenaDeConexion;

        public ImplCuentaDao(string conex)
        {
            _cadenaDeConexion = conex;
        }

        public async Task<ICuenta?> ObtenerCuentaPorId(long idCuenta)
        {
            ICuenta? cuenta = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM cuentas WHERE idCuenta = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", idCuenta);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        cuenta = new Cuenta();
                        cuenta.IdCuenta = reader.GetInt64(reader.GetOrdinal("idCuenta"));
                        cuenta.NombreCuenta = reader.GetString(reader.GetOrdinal("nombreCuenta"));
                        cuenta.Email = reader.GetString(reader.GetOrdinal("email"));
                        cuenta.Password = reader.GetString(reader.GetOrdinal("password"));
                        cuenta.EstaBloqueada = reader.GetBoolean(reader.GetOrdinal("estaBloqueada"));
                        cuenta.EstaBaneada = reader.GetBoolean(reader.GetOrdinal("estaBaneada"));
                    }
                }
            }
            return cuenta;
        }

        public async Task<List<ICuenta>> ObtenerTodasLasCuentas()
        {
            List<ICuenta> cuentas = new();

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM cuentas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        ICuenta cuenta = new Cuenta();

                        cuenta.IdCuenta = reader.GetInt64(reader.GetOrdinal("idCuenta"));
                        cuenta.NombreCuenta = reader.GetString(reader.GetOrdinal("nombreCuenta"));
                        cuenta.Email = reader.GetString(reader.GetOrdinal("email"));
                        cuenta.Password = reader.GetString(reader.GetOrdinal("password"));
                        cuenta.EstaBloqueada = reader.GetBoolean(reader.GetOrdinal("estaBloqueada"));
                        cuenta.EstaBaneada = reader.GetBoolean(reader.GetOrdinal("estaBaneada"));

                        cuentas.Add(cuenta);
                    }
                }
            }
            return cuentas;
        }

        public async Task<ICuenta?> ObtenerCuentaPorMail(string email)
        {
            ICuenta? cuenta = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM cuentas WHERE email COLLATE SQL_Latin1_General_CP1_CS_AS = @em";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@em", email);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        cuenta = new Cuenta();
                        cuenta.IdCuenta = reader.GetInt64(reader.GetOrdinal("idCuenta"));
                        cuenta.NombreCuenta = reader.GetString(reader.GetOrdinal("nombreCuenta"));
                        cuenta.Email = reader.GetString(reader.GetOrdinal("email"));
                        cuenta.Password = reader.GetString(reader.GetOrdinal("password"));
                        cuenta.EstaBloqueada = reader.GetBoolean(reader.GetOrdinal("estaBloqueada"));
                        cuenta.EstaBaneada = reader.GetBoolean(reader.GetOrdinal("estaBaneada"));
                    }
                }
            }
            return cuenta;
        }

        public async Task<ICuenta?> ObtenerCuentaPorNombre(string nombreCuenta)
        {
            ICuenta? cuenta = null;

            using (SqlConnection connection = new SqlConnection(_cadenaDeConexion))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM cuentas WHERE nombreCuenta COLLATE SQL_Latin1_General_CP1_CS_AS = @nc";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@nc", nombreCuenta);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        await reader.ReadAsync();

                        cuenta = new Cuenta();
                        cuenta.IdCuenta = reader.GetInt64(reader.GetOrdinal("idCuenta"));
                        cuenta.NombreCuenta = reader.GetString(reader.GetOrdinal("nombreCuenta"));
                        cuenta.Email = reader.GetString(reader.GetOrdinal("email"));
                        cuenta.Password = reader.GetString(reader.GetOrdinal("password"));
                        cuenta.EstaBloqueada = reader.GetBoolean(reader.GetOrdinal("estaBloqueada"));
                        cuenta.EstaBaneada = reader.GetBoolean(reader.GetOrdinal("estaBaneada"));
                    }
                }
            }
            return cuenta;
        }
    }
}