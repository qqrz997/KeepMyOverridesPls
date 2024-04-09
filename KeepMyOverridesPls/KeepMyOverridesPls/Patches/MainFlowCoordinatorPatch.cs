using HarmonyLib;

namespace KeepMyOverridesPls.Patches
{
    [HarmonyPatch(typeof(MainFlowCoordinator))]
    internal class MainFlowCoordinatorPatch
    {
        private static bool environmentOverride;
        private static bool colorOverride;

        [HarmonyPrefix]
        [HarmonyPatch("HandleMainMenuViewControllerPromoButtonWasPressed")]
        private static void HandleMainMenuViewControllerPromoButtonWasPressedPrefix(PlayerDataModel ____playerDataModel)
        {
            if (____playerDataModel)
            {
                environmentOverride = ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments;
                colorOverride = ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("HandleMainMenuViewControllerPromoButtonWasPressed")]
        private static void HandleMainMenuViewControllerPromoButtonWasPressedPostfix(ref PlayerDataModel ____playerDataModel)
        {
            if (____playerDataModel)
            {
                ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments = environmentOverride;
                ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors = colorOverride;
            }
        }
    }
}
