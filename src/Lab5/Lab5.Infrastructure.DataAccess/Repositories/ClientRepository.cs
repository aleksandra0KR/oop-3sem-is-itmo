using Application.Models;
using Itmo.ObjectOrientedProgramming.Lab5;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;
using Npgsql;

namespace ClassLibrary1Infrastructure.DataAccess.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IConnection _connecction;

    public ClientRepository(IConnection connectionProvider)
    {
        ArgumentNullException.ThrowIfNull(connectionProvider);
        _connecction = connectionProvider;
    }

    public Client? FindClientById(string login)
    {
        const string sql = "SELECT * FROM clients WHERE login = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(login);
        NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            return null;
        }

        return new Client(
            Id: reader.GetInt64(0),
            Login: reader.GetString(1),
            Password: reader.GetString(2),
            Access: reader.GetString(3));
    }

    public Client? AddClient(string login, string password, ClientAccess access)
    {
        const string sql = "INSERT INTO clients (login, password, access) VALUES (($1), ($2), ($3))";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);

        command.Parameters.AddWithValue(login);
        command.Parameters.AddWithValue(password);
        command.Parameters.AddWithValue(access);

        command.ExecuteNonQueryAsync();
        return FindClientById(login);
    }

    public void UpdateClient(Client client)
    {
        if (client is null) throw new ValueException("Empty Client");

        const string sql = "UPDATE clients SET login = ($1), password = ($2) WHERE id = ($3)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(client.Login);
        command.Parameters.AddWithValue(client.Password);
        command.Parameters.AddWithValue(client.Id);

        command.ExecuteNonQueryAsync();
    }

    public void DeleteClientById(long id)
    {
        const string sql = "DELETE FROM clients WHERE id = ($1)";

        NpgsqlCommand cmd = _connecction.DataSource.CreateCommand(sql);
        cmd.Parameters.AddWithValue(id);

        cmd.ExecuteNonQueryAsync();
    }
}