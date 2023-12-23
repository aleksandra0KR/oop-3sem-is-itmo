using Application.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Itmo.ObjectOrientedProgramming.Lab5.Exceptions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        if (builder is null)
        {
            throw new ValueException("Empty builder");
        }

        builder.MapEnum<ClientAccess>();
    }
}