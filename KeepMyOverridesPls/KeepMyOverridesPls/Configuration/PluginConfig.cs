using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace KeepMyOverridesPls.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; private set; }

        public PluginConfig()
        {
            Instance = this;
        }

        public virtual string NormalEnvironment { get; set; } = "CrabRaveEnvironment";

        public virtual string CircleEnvironment { get; set; } = "GlassDesertEnvironment";
    }
}
