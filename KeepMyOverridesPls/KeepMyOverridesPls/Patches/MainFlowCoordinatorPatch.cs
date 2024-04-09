using HarmonyLib;

namespace KeepMyOverridesPls.Patches
{
    [HarmonyPatch(typeof(MainFlowCoordinator))]
    internal class MainFlowCoordinatorPatch
    {
        private static bool? environmentOverride;
        private static bool? colorOverride;

        [HarmonyPrefix]
        [HarmonyPatch("HandleMainMenuViewControllerPromoButtonWasPressed")]
        private static void Prefix(ref PlayerDataModel ____playerDataModel, bool __state)
        {
            if (____playerDataModel)
            {
                environmentOverride = ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments;
                colorOverride = ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("HandleMainMenuViewControllerPromoButtonWasPressed")]
        private static void Postfix(ref PlayerDataModel ____playerDataModel, bool __state)
        {
            if (____playerDataModel)
            {
                ____playerDataModel.playerData.overrideEnvironmentSettings.overrideEnvironments = environmentOverride ?? false;
                ____playerDataModel.playerData.colorSchemesSettings.overrideDefaultColors = colorOverride ?? false;
            }
        }
    }
}
