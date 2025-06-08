using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class EnvironmentOverrideHook : IAffinity
    {
        private readonly PluginConfig config;

        public EnvironmentOverrideHook(PluginConfig config)
        {
            this.config = config;
        }

        [AffinityPostfix]
        [AffinityPatch(typeof(EnvironmentOverrideSettingsPanelController), nameof(EnvironmentOverrideSettingsPanelController.HandleOverrideEnvironmentsToggleValueChanged))]
        private void HandleOverrideEnvironmentsToggleValueChangedPostFix(bool isOn)
        {
            config.OverrideEnvironments = isOn;
        }
    }
}
