using Npgsql;
using System.Data;

namespace Saasu.Lib.Repositories
{
    internal class ConnectionFactory
    {
        public static IDbConnection GetConnection()
        {
            return new NpgsqlConnection(Settings.ConnectionString);
        }
    }
}