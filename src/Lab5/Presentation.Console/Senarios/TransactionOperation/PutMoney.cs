using Application.Contracts.Bills;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios.TransactionOperation;

public class PutMoney : IScenario
{
    private readonly IBillService _billService;
    private readonly Bill bill;
    private readonly decimal moneytotransfer;

    public PutMoney(IBillService billService, Bill billentered, decimal money)
    {
        if (billService is null || billentered is null) throw new ValueException("Bill can't be null");
        _billService = billService;
        bill = billentered;
        moneytotransfer = money;
    }

    public string Name { get; } = "Put";

    public void Run()
    {
        Result<Bill?> result = _billService.FindBillById(bill.Id);
        if (result.Type is ResultValues.NotFound)
        {
            AnsiConsole.WriteLine($"Your transaction is declined");

            AnsiConsole.Ask<string>("Ok");
            return;
        }

        _billService.PutMoney(bill.Id, moneytotransfer);
        AnsiConsole.WriteLine($"Your withdraw is succeed");

        AnsiConsole.Ask<string>("Ok");
    }
}