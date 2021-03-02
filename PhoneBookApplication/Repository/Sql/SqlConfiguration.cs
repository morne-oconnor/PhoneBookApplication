using PhoneBookApplication.Repository.Sql.Interfaces;

namespace PhoneBookApplication.Repository.Sql
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
