using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.Common;

namespace FranksGarage.DataAPI.Data
{
    public static class SqliteConnectionPool
    {
        private const int PoolSize = 500;

        private static readonly object Locker = new object();

        static SqliteConnectionPool()
        {
            Pool = new List<DbConnection>(PoolSize);
            Additional = new List<DbConnection>();
        }

        private static bool Finalized { get; set; }

        private static int CreatedConnectionsMax => PoolSize;
        private static int CreatedConnectionsCount { get; set; }

        private static List<DbConnection> Pool { get; }
        private static List<DbConnection> Additional { get; }

        public static DbConnection GetConnection(IConfiguration config)
        {
            if (Finalized)
            {
                throw new Exception("Connection pool was finalized.");
            }

            lock (Locker)
            {
                if (Pool.Count == 0)
                {
                    var connection = CreateAndOpenConnection(config);
                    if (CreatedConnectionsCount == CreatedConnectionsMax)
                    {
                        Additional.Add(connection);
                        LogAdditionalConnection();
                        return connection;
                    }
                    else
                    {
                        CreatedConnectionsCount++;
                        return connection;
                    }
                }
                else
                {
                    var connection = Pool[0];
                    Pool.RemoveAt(0);
                    return connection;
                }
            }
        }

        public static void ReleaseConnection(DbConnection connection)
        {
            if (Finalized)
            {
                CloseAndDisposeConnection(connection);
                return;
            }

            lock (Locker)
            {
                if (Additional.Contains(connection))
                {
                    Additional.Remove(connection);
                    CloseAndDisposeConnection(connection);
                }
                else
                {
                    Pool.Add(connection);
                }
            }
        }

        public static void Dispose()
        {
            lock (Locker)
            {
                foreach (var connection in Pool)
                {
                    CloseAndDisposeConnection(connection);
                }

                Finalized = true;
            }
        }

        private static DbConnection CreateAndOpenConnection(IConfiguration config)
        {
            // create connection string
            // var connectionString = new SqliteConnectionStringBuilder()
            // {
            //     DataSource = "demo.db",
            //     Password = "",
            //     Mode = SqliteOpenMode.ReadWriteCreate,
            // };

            // create and open connection
            var conn = new SqliteConnection(config.GetConnectionString("DefaultConnection"));
            // (connectionString.ToString());
            conn.Open();

            // enable write-ahead log
            var cmd = conn.CreateCommand();
            cmd.CommandText = "PRAGMA journal_mode = 'wal'";
            cmd.ExecuteNonQuery();

            return conn;
        }

        private static void CloseAndDisposeConnection(DbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            connection.Dispose();
        }

        private static void LogAdditionalConnection()
        {
            // it's important to know if your code is frequently opening additional connections
            // that way you can increase the pool size to improve performance
        }
    }

}
