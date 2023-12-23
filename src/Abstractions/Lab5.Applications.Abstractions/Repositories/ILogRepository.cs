using Application.Models.Transaction;

namespace Itmo.ObjectOrientedProgramming.Lab5.Repositories;

public interface ILogRepository
{
    IEnumerable<Transaction> GetClientTransactions(long clientId);
    void AddTransaction(long clientId, decimal money);
    void UpdateTransaction(Transaction transaction);
    void DeleteTransactionById(long id);
}