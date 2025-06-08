using SiraUtil.Affinity;

namespace KeepMyOverridesPls.Patches
{
    internal class PromoButtonPatch : IAffinity
    {
        // normally, the game will try to reset your override settings when pressing the promo button in the main menu.
        // this is done in order to ensure you use any potential new environments and colors for new content.
        // this patch makes sure the environments stay as they are.
        
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
