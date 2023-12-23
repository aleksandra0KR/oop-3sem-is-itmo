using ClassLibrary1Infrastructure.DataAccess;
using Itmo.ObjectOrientedProgramming.Lab5;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Lab5.Inftastructure.Extensions;

public static class ServiceScopeExtensions
{
    public static void UseInfrastructureDataAccess(this IServiceScope scope)
    {
        if (scope is null) throw new ValueException("scope can't be null");
        const string query = """
                             CREATE TABLE IF NOT EXISTS clients
                             (
                                 id bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
                                 login text NOT NULL,
                                 password text NOT NULL,
                                 access text NOT NULL
                             );

                             INSERT INTO clients (login, password, access) VALUES ('admin', 'admin', 'admin');

                             CREATE TABLE IF NOT EXISTS bills
                             (
                                 id bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
                                 clientId bigint NOT NULL REFERENCES clients (id),
                                 money DECIMAL NOT NULL,
                                 pinCode integer NOT NULL
                             );

                             CREATE TABLE IF NOT EXISTS transactions
                             (
                                 id bigint PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
                                 billId bigint NOT NULL REFERENCES bills (id),
                                 moneyChanged DECIMAL NOT NULL
                             );
                             """;
        IConnection connectionProvider =
            scope.ServiceProvider.GetRequiredService<IConnection>();
        using NpgsqlCommand command = connectionProvider.DataSource.CreateCommand(query);
        command.ExecuteNonQuery();
    }
}