using HarmonyLib;

namespace KeepMyOverridesPls.Patches
{
    [HarmonyPatch(typeof(PlayerDataFileModel))]
    internal class PlayerDataFileModelPatch
    {
        private static bool? environmentOverride;

        [HarmonyPrefix]
        [HarmonyPatch("LoadFromCurrentVersion")]
        private static void LoadFromCurrentVersionPrefix(PlayerSaveData playerSaveData)
        {
            if (!(playerSaveData == null || playerSaveData.localPlayers == null || playerSaveData.localPlayers.Count == 0))
            {
                environmentOverride = playerSaveData.localPlayers[0].overrideEnvironmentSettings.overrideEnvironments;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("LoadFromCurrentVersion")]
        private static void LoadFromCurrentVersionPostfix(ref PlayerData __result)
        {
            if (__result != null)
            {
                __result.overrideEnvironmentSettings.overrideEnvironments = environmentOverride ?? default;
            }
        }
    }
}
