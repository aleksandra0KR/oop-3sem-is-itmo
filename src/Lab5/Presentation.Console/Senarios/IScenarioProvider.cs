using System.Diagnostics.CodeAnalysis;

namespace Presentation.Senarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}