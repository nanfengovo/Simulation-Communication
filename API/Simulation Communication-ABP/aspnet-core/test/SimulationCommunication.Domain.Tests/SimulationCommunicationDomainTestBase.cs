using Volo.Abp.Modularity;

namespace SimulationCommunication;

/* Inherit from this class for your domain layer tests. */
public abstract class SimulationCommunicationDomainTestBase<TStartupModule> : SimulationCommunicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
