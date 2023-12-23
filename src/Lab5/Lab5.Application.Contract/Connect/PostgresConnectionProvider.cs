using Itmo.ObjectOrientedProgramming.Lab5;
using Npgsql;

namespace Application.Contracts.Connect;

public class PostgresConnectionProvider : IConnection
{
    public PostgresConnectionProvider(string connectionString)
    {
        DataSource = NpgsqlDataSource.Create(connectionString);
    }

    public NpgsqlDataSource DataSource { get; }
}