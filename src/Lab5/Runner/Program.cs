using DefaultNamespace.Application.Lab5.Application.Extensions;
using Lab5.Inftastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extentions;
using Spectre.Console;

internal class Program
{
    public static void Main()
    {
        var collection = new ServiceCollection();

        collection.AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 6432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddApplication()
            .AddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();

        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        while (true)
        {
            scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}