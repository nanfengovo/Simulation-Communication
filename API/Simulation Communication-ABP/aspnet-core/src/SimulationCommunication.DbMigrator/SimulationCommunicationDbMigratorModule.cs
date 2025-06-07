using SimulationCommunication.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SimulationCommunication.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SimulationCommunicationEntityFrameworkCoreModule),
    typeof(SimulationCommunicationApplicationContractsModule)
    )]
public class SimulationCommunicationDbMigratorModule : AbpModule
{
}
