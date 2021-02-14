using PhoneBookApplication.Sidecar.Repository.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Sidecar.Repository.Sql
{
    public class SqlConfiguration : ISqlConfiguration
    {
        public string ConnectionString { get; set; }
        public SqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
