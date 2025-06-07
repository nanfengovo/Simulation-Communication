using Volo.Abp.Modularity;

namespace SimulationCommunication;

[DependsOn(
    typeof(SimulationCommunicationApplicationModule),
    typeof(SimulationCommunicationDomainTestModule)
)]
public class SimulationCommunicationApplicationTestModule : AbpModule
{

}
