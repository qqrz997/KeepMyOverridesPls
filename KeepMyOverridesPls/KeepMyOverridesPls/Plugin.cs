using IPA;
using IPA.Logging;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using KeepMyOverridesPls.Configuration;
using KeepMyOverridesPls.Installers;

namespace KeepMyOverridesPls
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public Plugin(Logger logger, Config config, Zenjector zenjector)
        {
            PluginConfig pluginConfig = config.Generated<PluginConfig>();

            zenjector.UseLogger(logger);
            zenjector.Install<AppInstaller>(Location.App, pluginConfig);
        }
    }
}
