using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class MainFlowCoordinatorPatch : IAffinity
    {
        private bool environmentOverride;
        private bool colorOverride;

        [AffinityPrefix]
        [AffinityPatch(typeof(MainFlowCoordinator), nameof(MainFlowCoordinator.HandleMainMenuViewControllerPromoButtonWasPressed))]
        private void HandleMainMenuViewControllerPromoButtonWasPressedPrefix(PlayerDataModel ____playerDataModel)
        {
            environmentOverride = ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments;
            colorOverride = ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors;
        }

        [AffinityPostfix]
        [AffinityPatch(typeof(MainFlowCoordinator), nameof(MainFlowCoordinator.HandleMainMenuViewControllerPromoButtonWasPressed))]
        private void HandleMainMenuViewControllerPromoButtonWasPressedPostfix(ref PlayerDataModel ____playerDataModel)
        {
            ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments = environmentOverride;
            ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors = colorOverride;
        }
    } 
}
