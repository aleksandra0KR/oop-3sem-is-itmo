using Itmo.ObjectOrientedProgramming.Lab5;
using Npgsql;
namespace ConnectionDB;

public class ConnectionPostgresDB : IConnection
{
    public ConnectionPostgresDB(string connectionString)
    {
        DataSource = NpgsqlDataSource.Create(connectionString);
    }

    public NpgsqlDataSource DataSource { get; }
}