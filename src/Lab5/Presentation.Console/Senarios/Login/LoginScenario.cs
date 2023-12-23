using Application.Contracts;
using Application.Models;
using Application.Models.Result;
using Spectre.Console;

namespace Presentation.Senarios.Login;

public class LoginScenario : IScenario
{
    private readonly IClientService _clientService;

    public LoginScenario(IClientService userService)
    {
        _clientService = userService;
    }

    public string Name => "Login";

    public void Run()
    {
        string login = AnsiConsole.Ask<string>("Enter your login");
        string password = AnsiConsole.Ask<string>("Enter your password");

        Result<Client> result = _clientService.Login(login, password);

        AnsiConsole.WriteLine(result.Data.ToString());
        AnsiConsole.Ask<string>("Ok");
    }
}