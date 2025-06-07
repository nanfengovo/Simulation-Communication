using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimulationCommunication.Data;
using Volo.Abp.DependencyInjection;

namespace SimulationCommunication.EntityFrameworkCore;

public class EntityFrameworkCoreSimulationCommunicationDbSchemaMigrator
    : ISimulationCommunicationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSimulationCommunicationDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SimulationCommunicationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SimulationCommunicationDbContext>()
            .Database
            .MigrateAsync();
    }
}
