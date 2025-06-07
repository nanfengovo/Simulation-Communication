using SimulationCommunication.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SimulationCommunication.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SimulationCommunicationController : AbpControllerBase
{
    protected SimulationCommunicationController()
    {
        LocalizationResource = typeof(SimulationCommunicationResource);
    }
}
