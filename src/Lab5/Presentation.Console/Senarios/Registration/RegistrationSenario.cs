using Application.Contracts;
using Application.Models;
using Application.Models.Result;
using Itmo.ObjectOrientedProgramming.Lab3;
using Spectre.Console;

namespace Presentation.Senarios.Registration;

public class RegistrationSenario : IScenario
{
    private readonly IClientService _clientService;

    public RegistrationSenario(IClientService userService)
    {
        _clientService = userService ?? throw new ValueException("empty userService");
    }

    public string Name => "Registration";

    public void Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your login");
        string password = AnsiConsole.Ask<string>("Enter your password");
        ClientAccess access = AnsiConsole.Ask<ClientAccess>("Enter your access");

        Result<Client> result = _clientService.Registration(login, password, access);

        AnsiConsole.WriteLine(result.Data.ToString());
        AnsiConsole.Ask<string>("Ok");
    }
}