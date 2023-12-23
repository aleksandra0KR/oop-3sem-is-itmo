using Microsoft.Extensions.DependencyInjection;
using Presentation.Senarios;
using Presentation.Senarios.Login;

namespace Presentation.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        return collection;
    }
}