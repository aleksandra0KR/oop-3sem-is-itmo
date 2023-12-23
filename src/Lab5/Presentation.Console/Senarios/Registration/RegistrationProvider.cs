using System.Diagnostics.CodeAnalysis;
using Application.Contracts;
using Itmo.ObjectOrientedProgramming.Lab3;
using Presentation.Senarios.Login;

namespace Presentation.Senarios.Registration;

public class RegistrationProvider : IScenarioProvider
{
    private readonly IClientService _service;
    private readonly ICurrentClientService _currentUser;

    public RegistrationProvider(
        IClientService service,
        ICurrentClientService currentUser)
    {
        if (service is null || currentUser is null) throw new ValueException("Empty Values for Login");
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Client is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_service);
        return true;
    }
}