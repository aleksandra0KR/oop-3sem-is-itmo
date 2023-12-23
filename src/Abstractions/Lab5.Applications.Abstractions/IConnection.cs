using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5;

public interface IConnection
{
    NpgsqlDataSource DataSource { get; }
}