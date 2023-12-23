using Application.Models.Transaction;
using Itmo.ObjectOrientedProgramming.Lab5;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;
using Npgsql;

namespace ClassLibrary1Infrastructure.DataAccess.Repositories;

public class LogPerository : ILogRepository
{
    private readonly IConnection _connecction;

    public LogPerository(IConnection connectionProvider)
    {
        _connecction = connectionProvider ?? throw new ValueException("Empty connectionProvider");
    }

    public IEnumerable<Transaction> GetClientTransactions(long clientId)
    {
        const string sql = "SELECT * FROM transactions WHERE billId = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(clientId);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<Transaction> operations = new();
        while (reader.Read())
        {
            operations.Add(new Transaction(
                Id: reader.GetInt64(0),
                BillId: reader.GetInt64(1),
                MoneyChanged: (int)reader.GetDecimal(2)));
        }

        return operations;
    }

    public void AddTransaction(long clientId, decimal money)
    {
        const string sql = "INSERT INTO transactions (billId, money) VALUES (($1), ($2))";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(clientId);
        command.Parameters.AddWithValue(money);
        command.ExecuteNonQueryAsync();
    }

    public void UpdateTransaction(Transaction transaction)
    {
        if (transaction is null) throw new ValueException("Operation is null");

        const string sql = "UPDATE transactions SET billId = ($1), moneyChanged = ($2) WHERE id = ($3)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(transaction.BillId);
        command.Parameters.AddWithValue(transaction.MoneyChanged);
        command.Parameters.AddWithValue(transaction.Id);

        command.ExecuteNonQueryAsync();
    }

    public void DeleteTransactionById(long id)
    {
        const string sql = "DELETE FROM transactions WHERE id = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(id);

        command.ExecuteNonQueryAsync();
    }
}