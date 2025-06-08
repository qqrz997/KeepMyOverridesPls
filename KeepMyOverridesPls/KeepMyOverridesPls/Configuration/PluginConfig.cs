using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace KeepMyOverridesPls.Configuration
{
    internal class PluginConfig
    {
        public virtual bool OverrideEnvironments { get; set; } = false;
        public virtual string NormalEnvironment { get; set; } = "CrabRaveEnvironment";
        public virtual string CircleEnvironment { get; set; } = "GlassDesertEnvironment";
    }
}
