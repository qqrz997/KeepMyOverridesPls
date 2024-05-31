using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class OverrideEnvironmentSettingsPatch(PluginConfig config) : IAffinity
    {
        private readonly PluginConfig config = config;

        [AffinityPostfix]
        [AffinityPatch(typeof(OverrideEnvironmentSettings), nameof(OverrideEnvironmentSettings.SetEnvironmentInfoForType))]
        private void SetEnvironmentInfoForTypePostFix(EnvironmentType environmentType, EnvironmentInfoSO environmentInfo)
        {
            // this gets called when the player selects an environment from the dropdown
            switch (environmentType)
            {
                case EnvironmentType.Normal:
                    config.NormalEnvironment = environmentInfo.serializedName; break;

                case EnvironmentType.Circle:
                    config.CircleEnvironment = environmentInfo.serializedName; break;
            }
        }
    }
}
