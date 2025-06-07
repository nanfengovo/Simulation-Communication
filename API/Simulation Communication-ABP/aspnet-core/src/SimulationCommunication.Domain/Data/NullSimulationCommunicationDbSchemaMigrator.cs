using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SimulationCommunication.Data;

/* This is used if database provider does't define
 * ISimulationCommunicationDbSchemaMigrator implementation.
 */
public class NullSimulationCommunicationDbSchemaMigrator : ISimulationCommunicationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
