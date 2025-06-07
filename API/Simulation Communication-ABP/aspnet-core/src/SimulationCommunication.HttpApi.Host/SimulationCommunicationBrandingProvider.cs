using Microsoft.Extensions.Localization;
using SimulationCommunication.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SimulationCommunication;

[Dependency(ReplaceServices = true)]
public class SimulationCommunicationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SimulationCommunicationResource> _localizer;

    public SimulationCommunicationBrandingProvider(IStringLocalizer<SimulationCommunicationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
