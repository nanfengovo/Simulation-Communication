using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimulationCommunication.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SimulationCommunicationDbContextFactory : IDesignTimeDbContextFactory<SimulationCommunicationDbContext>
{
    public SimulationCommunicationDbContext CreateDbContext(string[] args)
    {
        SimulationCommunicationEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SimulationCommunicationDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SimulationCommunicationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SimulationCommunication.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
