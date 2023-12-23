using Application.Bills;
using Application.Clients;
using Application.Contracts;
using Application.Contracts.Bills;
using Application.Contracts.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace DefaultNamespace.Application.Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IClientService, ClientService>();
        collection.AddScoped<IBillService, BillService>();
        collection.AddScoped<ITransactionService, ITransactionService>();

        return collection;
    }
}