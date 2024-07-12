using System.Data;
using System.Data.SqlClient;

namespace PruebasTecnicas.Infrastructure.Data
{
    public class DbContext : IDisposable
    {
        private readonly SqlConnection _connection;

        public DbContext()
        {
            _connection = new SqlConnection(DatabaseSettings.ConnectionString);
            _connection.Open();
        }

        public IDbConnection Connection => _connection;

        public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }
    }
}
