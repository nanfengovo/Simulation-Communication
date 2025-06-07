using SimulationCommunication.Samples;
using Xunit;

namespace SimulationCommunication.EntityFrameworkCore.Applications;

[Collection(SimulationCommunicationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SimulationCommunicationEntityFrameworkCoreTestModule>
{

}
