using SimulationCommunication.Samples;
using Xunit;

namespace SimulationCommunication.EntityFrameworkCore.Domains;

[Collection(SimulationCommunicationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SimulationCommunicationEntityFrameworkCoreTestModule>
{

}
