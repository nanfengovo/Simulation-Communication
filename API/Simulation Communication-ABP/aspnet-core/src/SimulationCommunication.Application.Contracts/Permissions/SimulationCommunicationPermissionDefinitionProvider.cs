using SimulationCommunication.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SimulationCommunication.Permissions;

public class SimulationCommunicationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SimulationCommunicationPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SimulationCommunicationPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SimulationCommunicationResource>(name);
    }
}
