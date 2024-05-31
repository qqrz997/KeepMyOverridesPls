using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class MainFlowCoordinatorPatch : IAffinity
    {
        private bool overrideEnvironments;
        private bool overrideDefaultColors;

        [AffinityPrefix]
        [AffinityPatch(typeof(MainFlowCoordinator), nameof(MainFlowCoordinator.HandleMainMenuViewControllerPromoButtonWasPressed))]
        private void HandleMainMenuViewControllerPromoButtonWasPressedPrefix(PlayerDataModel ____playerDataModel)
        {
            overrideEnvironments = ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments;
            overrideDefaultColors = ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors;
        }

        [AffinityPostfix]
        [AffinityPatch(typeof(MainFlowCoordinator), nameof(MainFlowCoordinator.HandleMainMenuViewControllerPromoButtonWasPressed))]
        private void HandleMainMenuViewControllerPromoButtonWasPressedPostfix(ref PlayerDataModel ____playerDataModel)
        {
            ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments = overrideEnvironments;
            ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors = overrideDefaultColors;
        }
    } 
}
