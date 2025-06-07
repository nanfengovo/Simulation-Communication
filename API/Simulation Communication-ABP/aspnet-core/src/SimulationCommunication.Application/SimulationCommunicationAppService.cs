using System;
using System.Collections.Generic;
using System.Text;
using SimulationCommunication.Localization;
using Volo.Abp.Application.Services;

namespace SimulationCommunication;

/* Inherit your application services from this class.
 */
public abstract class SimulationCommunicationAppService : ApplicationService
{
    protected SimulationCommunicationAppService()
    {
        LocalizationResource = typeof(SimulationCommunicationResource);
    }
}
