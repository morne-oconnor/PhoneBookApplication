using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PhoneBookApplication.Repository.Sql.Interfaces
{
    public interface ISqlRepository
    {
        Task<List<T>> QueryList<T>(string storedProcedure, object parameterObject = null);
        Task<T> QueryOne<T>(string storedProcedure, object parameterObject = null);
        Task<int> Execute(string storedProcedure, object parameterObject = null);
        Task<List<T>> TransactionList<T>(Func<SqlTransaction, List<T>, List<T>> execution, List<T> models);
        Task<T> TransactionOne<T>(Func<SqlTransaction, T, T> execution, T models);
        Task<bool> DatabaseAvailable();
    }
}
