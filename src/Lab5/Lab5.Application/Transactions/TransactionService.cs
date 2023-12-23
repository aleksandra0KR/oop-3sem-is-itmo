using System.ComponentModel.DataAnnotations;
using Application.Contracts.Transactions;
using Application.Models.Transaction;
using Itmo.ObjectOrientedProgramming.Lab5.Repositories;

namespace Application.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ILogRepository _logRepository;

    public TransactionService(ILogRepository logRepository)
    {
        _logRepository = logRepository ?? throw new ValidationException("Empty logRepository");
    }

    public IEnumerable<Transaction> GetBillTransactions(long billId)
    {
        return _logRepository.GetClientTransactions(billId);
    }
}