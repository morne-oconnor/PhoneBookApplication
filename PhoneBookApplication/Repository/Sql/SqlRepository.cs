using Dapper;
using PhoneBookApplication.Repository.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhoneBookApplication.Repository.Sql
{
    public class SqlRepository : ISqlRepository
    {
        protected ISqlConfiguration _configuration;

        public SqlRepository(ISqlConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<T> QueryList<T>(string storedProcedure, object parameterObject)
        {
            using var connection = new SqlConnection(_configuration.ConnectionString);
            connection.Open();

            var models = connection.Query<T>(storedProcedure, parameterObject).ToList();

            return models;
        }
        public T QueryOne<T>(string storedProcedure, object parameterObject)
        {
            using var connection = new SqlConnection(_configuration.ConnectionString);
            connection.Open();

            var model = connection.Query<T>(storedProcedure, parameterObject).FirstOrDefault();

            return model;
        }
        public void Execute(string storedProcedure, object parameterObject)
        {
            using var connection = new SqlConnection(_configuration.ConnectionString);
            connection.Open();

            connection.Execute(storedProcedure, parameterObject, null, null, CommandType.StoredProcedure);
        }
        public List<T> TransactionList<T>(Func<SqlTransaction, List<T>, List<T>> execution, List<T> models)
        {
            using var connection = new SqlConnection(_configuration.ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            models = (List<T>)execution.DynamicInvoke(transaction, models);

            transaction.Commit();
            return models;

        }
        public T TransactionOne<T>(Func<SqlTransaction, T, T> execution, T model)
        {
            using var connection = new SqlConnection(_configuration.ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            model = (T)execution.DynamicInvoke(transaction, model);

            transaction.Commit();

            return model;
        }
        public bool DatabaseAvailable()
        {
            int result;
            using var connection = new SqlConnection(_configuration.ConnectionString);

            connection.Open();

            result = (int)connection.ExecuteScalar("SELECT 1");
            return result > 0;
        }
    }
}
