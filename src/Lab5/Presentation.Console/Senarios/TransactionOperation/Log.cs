using Application.Contracts.Transactions;
using Application.Models.Bills;
using Application.Models.Transaction;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios.TransactionOperation;

public class Log : IScenario
{
    private readonly ITransactionService transactionService;
    private readonly Bill bill;

    public Log(ITransactionService transaction, Bill billentered)
    {
        if (transaction is null || billentered is null) throw new ValueException("Bill can't be null");
        transactionService = transaction;
        bill = billentered;
    }

    public string Name { get; } = "Log";
    public void Run()
    {
        IEnumerable<Transaction> result = transactionService.GetBillTransactions(bill.Id);
        if (result is null)
        {
            AnsiConsole.WriteLine($"No transaction");

            AnsiConsole.Ask<string>("Ok");
            return;
        }

        AnsiConsole.WriteLine($"Transaction History:");
        foreach (Transaction transaction in result)
        {
            AnsiConsole.WriteLine(transaction.ToString());
        }

        AnsiConsole.Ask<string>("Ok");
    }
}