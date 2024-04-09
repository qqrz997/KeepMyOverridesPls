using HarmonyLib;
using KeepMyOverridesPls.Configuration;

namespace KeepMyOverridesPls.Patches
{
    [HarmonyPatch(typeof(PlayerDataFileModel))]
    internal class PlayerDataFileModelPatch
    {
        private static bool environmentOverride;

        private static string normalEnvironment 
        { 
            get => PluginConfig.Instance.NormalEnvironment; 
            set => PluginConfig.Instance.NormalEnvironment = value; 
        }

        private static string circleEnvironment
        {
            get => PluginConfig.Instance.CircleEnvironment;
            set => PluginConfig.Instance.CircleEnvironment = value;
        }

        [HarmonyPrefix]
        [HarmonyPatch("LoadFromCurrentVersion")]
        private static void LoadFromCurrentVersionPrefix(PlayerSaveData playerSaveData)
        {
            if (!(playerSaveData == null || playerSaveData.localPlayers == null || playerSaveData.localPlayers.Count == 0))
            {
                PlayerSaveData.LocalPlayer localPlayer = playerSaveData.localPlayers[0];

                environmentOverride = localPlayer.overrideEnvironmentSettings.overrideEnvironments;

                if (!string.IsNullOrEmpty(localPlayer.overrideEnvironmentSettings.overrideNormalEnvironmentName))
                {
                    normalEnvironment = localPlayer.overrideEnvironmentSettings.overrideNormalEnvironmentName;
                }

                if (!string.IsNullOrEmpty(localPlayer.overrideEnvironmentSettings.override360EnvironmentName))
                {
                    circleEnvironment = localPlayer.overrideEnvironmentSettings.override360EnvironmentName;
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("LoadFromCurrentVersion")]
        private static void LoadFromCurrentVersionPostfix(ref PlayerData __result, EnvironmentsListModel ____environmentsListModel)
        {
            if (__result != null)
            {
                __result.overrideEnvironmentSettings.overrideEnvironments = environmentOverride;

                if (normalEnvironment != null)
                {
                    __result.overrideEnvironmentSettings.SetEnvironmentInfoForType(EnvironmentType.Normal, ____environmentsListModel.GetEnvironmentInfoBySerializedName(normalEnvironment));
                }

                if (circleEnvironment != null)
                {
                    __result.overrideEnvironmentSettings.SetEnvironmentInfoForType(EnvironmentType.Circle, ____environmentsListModel.GetEnvironmentInfoBySerializedName(circleEnvironment));
                }
            }
        }
    }
}
