using Biblioteca.Common;
using Biblioteca.DAL.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DAL
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string connectionString;

        public DatabaseRepository(IOptions<AppSettings> appSettings)
        {
            connectionString = appSettings.Value.ConnectionString;
        }

        public async Task<List<T>> GetDataByQueryAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<T>(query, parameters);
                    connection.Close();
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataByQuey: " + ex.Message);
            }
        }

        public async Task<int> InsertAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int result = await connection.QuerySingleOrDefaultAsync<int>(query, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta de insertar: " + ex.Message);
            }
        }

        public async Task<T?> UpdateAsync<T>(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<T>(query, parameters);
                    connection.Close();
                    if (result != null && result.Any())
                    {
                        return result.FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta de actualizar: " + ex.Message);
            }
            return default;
        }

        public async Task<bool> DeleteAsync(string query, DynamicParameters? parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    bool result = await connection.QuerySingleOrDefaultAsync<bool>(query, parameters);
                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la consulta de eliminar: " + ex.Message);

            }
        }
    }
}
