using Application.Contracts.Bills;
using Application.Models.Bills;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios.TransactionOperation;

public class CheckMoney : IScenario
{
    private readonly IBillService _billService;
    private readonly Bill bill;

    public CheckMoney(IBillService billService, Bill billentered)
    {
        if (billService is null || billentered is null) throw new ValueException("Bill can't be null");
        _billService = billService;
        bill = billentered;
    }

    public string Name { get; } = "Check";

    public void Run()
    {
        Result<Bill?> result = _billService.FindBillById(bill.Id);
        if (result.Type is ResultValues.NotFound)
        {
            AnsiConsole.WriteLine($"Bill is apsent");

            AnsiConsole.Ask<string>("Ok");
            return;
        }

        AnsiConsole.WriteLine("Your balance:" + result.Data?.Money);

        AnsiConsole.Ask<string>("Ok");
    }
}