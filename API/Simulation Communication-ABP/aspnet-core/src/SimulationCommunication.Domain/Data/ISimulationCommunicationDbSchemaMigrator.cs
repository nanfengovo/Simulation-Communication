using System.Threading.Tasks;

namespace SimulationCommunication.Data;

public interface ISimulationCommunicationDbSchemaMigrator
{
    Task MigrateAsync();
}
