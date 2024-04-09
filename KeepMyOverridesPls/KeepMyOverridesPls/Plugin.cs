using IPA;
using System;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;
using Harmony = HarmonyLib.Harmony;
using Config = IPA.Config.Config;
using KeepMyOverridesPls.Configuration;
using IPA.Config.Stores;

namespace KeepMyOverridesPls
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public const string PluginGUID = "com.github.qqrz997.KeepMyOverridesPls";
        internal static readonly Harmony harmony = new Harmony(PluginGUID);

        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger logger, Config config)
        {
            PluginConfig pluginConfig = config.Generated<PluginConfig>();
            Log = logger;
        }

        [OnEnable]
        public void OnEnable()
        {
            ApplyHarmonyPatches();
        }

        [OnDisable]
        public void OnDisable()
        {
            RemoveHarmonyPatches();
        }

        private static void ApplyHarmonyPatches()
        {
            try
            {
                Log.Debug("Applying Harmony patches");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Log.Error("Error applying Harmony patches: " + ex.Message);
                Log.Debug(ex);
            }
        }

        private static void RemoveHarmonyPatches()
        {
            try
            {
                Log.Debug("Removing Harmony patches");
                harmony.UnpatchSelf();
            }
            catch (Exception ex)
            {
                Log.Error("Error removing Harmony patches: " + ex.Message);
                Log.Debug(ex);
            }
        }
    }
}
