using System.Collections.ObjectModel;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab5;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;
using Npgsql;
namespace ClassLibrary1Infrastructure.DataAccess.Repositories;

public class BillRepository : IBillRepository
{
    private readonly IConnection _connecction;
    public BillRepository(IConnection connectionProvider)
    {
        _connecction = connectionProvider ?? throw new Itmo.ObjectOrientedProgramming.Lab3.ValueException("Empty connectionProvider");
    }

    public IEnumerable<Bill> GetClientBills(long clientId)
    {
        const string sql = "SELECT * FROM clients WHERE clientId = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(clientId);
        NpgsqlDataReader reader = command.ExecuteReader();
        Collection<Bill> bills = new();
        while (reader.Read())
        {
            bills.Add(new Bill(
                reader.GetInt64(0),
                reader.GetInt64(1),
                reader.GetDecimal(2),
                reader.GetInt32(3)));
        }

        return bills;
    }

    public Bill? FindBillById(long id)
    {
        const string sql = "SELECT * FROM clients WHERE id = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        NpgsqlDataReader reader = command.ExecuteReader();

        command.Parameters.AddWithValue(id);
        command.ExecuteNonQueryAsync();
        if (!reader.Read())
            return null;

        return new Bill(
            Id: reader.GetInt64(0),
            UserId: reader.GetInt64(1),
            Money: reader.GetDecimal(2),
            PinCode: reader.GetInt32(3));
    }

    public Result<string> AddBill(long clientId, int pinCode)
    {
        const string sql = "INSERT INTO clients (clientId, money, pinCode) VALUES (($1), 0, ($2))";
        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(clientId);
        command.Parameters.AddWithValue(pinCode);

        command.ExecuteNonQueryAsync();
        if (FindBillById(clientId) is not null)
        {
            return new Result<string>(
                ResultValues.Success,
                "successfully added to the system");
        }

        return new Result<string>(
            ResultValues.NotFound,
            "successfully added to the system");
    }

    public Bill? UpdateBill(Bill bill)
    {
        if (bill is null) throw new ValueException("Bill is null");
        const string sql = "UPDATE clients SET (clientId, money, pinCode) = (($1), ($2), ($3)) WHERE id = ($4)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(bill.UserId);
        command.Parameters.AddWithValue(bill.Money);
        command.Parameters.AddWithValue(bill.PinCode);
        command.Parameters.AddWithValue(bill.Id);
        command.ExecuteNonQueryAsync();

        return FindBillById(bill.UserId);
    }

    public Result<string> DeleteBillById(long id)
    {
        const string sql = "DELETE FROM clients WHERE id = ($1)";

        NpgsqlCommand command = _connecction.DataSource.CreateCommand(sql);
        command.Parameters.AddWithValue(id);

        command.ExecuteNonQueryAsync();
        return new Result<string>(ResultValues.Success, "Success");
    }
}