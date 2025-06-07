using Volo.Abp.Modularity;

namespace SimulationCommunication;

[DependsOn(
    typeof(SimulationCommunicationDomainModule),
    typeof(SimulationCommunicationTestBaseModule)
)]
public class SimulationCommunicationDomainTestModule : AbpModule
{

}
