using Dapper;
using PhoneBookApplication.Repository.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PhoneBookApplication.Repository.Sql
{
    public class SqlRepository : ISqlRepository
    {
        private readonly ISqlConfiguration _configuration;

        public SqlRepository(ISqlConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<T>> QueryList<T>(string storedProcedure, object parameterObject = null)
        {
            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();
            
            return (List<T>)await connection.QueryAsync<T>(storedProcedure, parameterObject);
        }
        public async Task<T> QueryOne<T>(string storedProcedure, object parameterObject = null)
        {
            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();
            
            return  await connection.QueryFirstAsync<T>(storedProcedure, parameterObject);
        }
        public async Task<int> Execute(string storedProcedure, object parameterObject = null)
        {
            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();

            return await connection.ExecuteAsync(storedProcedure, parameterObject, 
                null, null, CommandType.StoredProcedure);
        }
        public async Task<List<T>> TransactionList<T>(Func<SqlTransaction, List<T>, List<T>> execution, List<T> models)
        {
            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();

            using DbTransaction transaction = await connection.BeginTransactionAsync();
            List<T> result  = (List<T>)execution.DynamicInvoke(transaction, models);
            await transaction.CommitAsync();

            return result;
        }
        public async Task<T> TransactionOne<T>(Func<SqlTransaction, T, T> execution, T model)
        {
            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();

            using DbTransaction transaction = await connection.BeginTransactionAsync();
            T result = (T)execution.DynamicInvoke(transaction, model);
            await transaction.CommitAsync();

            return result;
        }
        public async Task<bool> DatabaseAvailable()
        {
            int result;

            using SqlConnection connection = new SqlConnection(_configuration.ConnectionString);
            await connection.OpenAsync();
            result = (int)connection.ExecuteScalar("SELECT 1");

            return result > 0;
        }
    }
}
