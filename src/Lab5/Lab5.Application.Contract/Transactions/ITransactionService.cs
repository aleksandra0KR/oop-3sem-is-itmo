using Application.Models.Transaction;
namespace Application.Contracts.Transactions;

public interface ITransactionService
{
    IEnumerable<Transaction> GetBillTransactions(long billId);
}