using Application.Contracts.Bills;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios.TransactionOperation;

public class Withdraw : IScenario
{
    private readonly IBillService _billService;
    private readonly Bill bill;
    private readonly int pincode;
    private readonly decimal moneytotransfer;

    public Withdraw(IBillService billService, Bill billentered, int pincodeentered, decimal money)
    {
        if (billService is null || billentered is null) throw new ValueException("Bill can't be null");
        _billService = billService;
        bill = billentered;
        pincode = pincodeentered;
        moneytotransfer = money;
    }

    public string Name { get; } = "Withdraw";

    public void Run()
    {
        Result<Bill?> result = _billService.FindBillById(bill.Id);
        if (result.Type is ResultValues.NotFound)
        {
           AnsiConsole.WriteLine($"Your withdraw is declined");

           AnsiConsole.Ask<string>("Ok");
           return;
        }

        _billService.WithdrawMoney(bill.Id, pincode, moneytotransfer);
        AnsiConsole.WriteLine($"Your withdraw is succeed");

        AnsiConsole.Ask<string>("Ok");
    }
}