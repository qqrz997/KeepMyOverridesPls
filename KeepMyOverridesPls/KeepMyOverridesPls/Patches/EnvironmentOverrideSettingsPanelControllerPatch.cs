using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class EnvironmentOverrideSettingsPanelControllerPatch(PluginConfig config) : IAffinity
    {
        private readonly PluginConfig config = config;

        [AffinityPostfix]
        [AffinityPatch(typeof(EnvironmentOverrideSettingsPanelController), nameof(EnvironmentOverrideSettingsPanelController.HandleOverrideEnvironmentsToggleValueChanged))]
        private void HandleOverrideEnvironmentsToggleValueChangedPostFix(bool isOn)
        {
            config.OverrideEnvironments = isOn;
        }
    }
}
