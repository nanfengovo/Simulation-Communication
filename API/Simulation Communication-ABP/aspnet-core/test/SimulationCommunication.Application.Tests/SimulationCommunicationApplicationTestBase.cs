using Volo.Abp.Modularity;

namespace SimulationCommunication;

public abstract class SimulationCommunicationApplicationTestBase<TStartupModule> : SimulationCommunicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
