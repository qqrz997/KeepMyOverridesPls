using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class PlayerDataFileModelPatch(PluginConfig config, EnvironmentsListModel environmentsListModel) : IAffinity
    {
        private readonly PluginConfig config = config;
        private readonly EnvironmentsListModel environmentsListModel = environmentsListModel;

        [AffinityPrefix]
        [AffinityPatch(typeof(PlayerDataFileModel), nameof(PlayerDataFileModel.CreateDefaultOverrideEnvironmentSettings))]
        private bool CreateDefaultOverrideEnvironmentSettingsPrefix(ref OverrideEnvironmentSettings __result)
        {
            var overrideEnvironmentSettings = new OverrideEnvironmentSettings();
            overrideEnvironmentSettings.overrideEnvironments = config.OverrideEnvironments;
            overrideEnvironmentSettings.SetEnvironmentInfoForType(EnvironmentType.Normal, environmentsListModel.GetEnvironmentInfoBySerializedName(config.NormalEnvironment));
            overrideEnvironmentSettings.SetEnvironmentInfoForType(EnvironmentType.Circle, environmentsListModel.GetEnvironmentInfoBySerializedName(config.CircleEnvironment));
            __result = overrideEnvironmentSettings;
            return false;
        }
    }
}
