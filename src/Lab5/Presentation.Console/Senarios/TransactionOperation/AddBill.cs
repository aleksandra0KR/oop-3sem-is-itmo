using Application.Contracts.Bills;
using Application.Models.Bills;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios;

public class AddBill : IScenario
{
    private readonly IBillService _billService;
    private readonly long iD;

    public AddBill(IBillService billService, long id)
    {
        _billService = billService;
        iD = id;
    }

    public string Name => "Add bill";

    public void Run()
    {
        IEnumerable<Bill> bills = _billService.GetClientBills(iD);
        if (bills is null) throw new ValueException("Bills are null");

        SelectionPrompt<Bill> selector = new SelectionPrompt<Bill>()
            .Title("Select Bill")
            .AddChoices(bills);

        Bill? shop = AnsiConsole.Prompt(selector);

        AnsiConsole.WriteLine($"You selected {shop.Id}");

        AnsiConsole.Ask<string>("Ok");
    }
}