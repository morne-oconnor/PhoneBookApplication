using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhoneBookApplication.Repository.Sql.Interfaces
{
    public interface ISqlRepository
    {
        List<T> QueryList<T>(string storedProcedure, object parameterObject);
        T QueryOne<T>(string storedProcedure, object parameterObject);
        void Execute(string storedProcedure, object parameterObject);
        List<T> TransactionList<T>(Func<SqlTransaction, List<T>, List<T>> execution, List<T> models);
        T TransactionOne<T>(Func<SqlTransaction, T, T> execution, T models);
        bool DatabaseAvailable();

    }
}
