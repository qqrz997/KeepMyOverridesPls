using KeepMyOverridesPls.Configuration;
using KeepMyOverridesPls.Patches;
using Zenject;

namespace KeepMyOverridesPls.Installers;

internal class AppInstaller : Installer
{
    private readonly PluginConfig config;

    public AppInstaller(PluginConfig config)
    {
        this.config = config;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(config).AsSingle();
        Container.BindInterfacesTo<Overrider>().AsSingle();

        // Patches
        Container.BindInterfacesTo<PromoButtonPatch>().AsSingle();
        Container.BindInterfacesTo<EnvironmentSettingsHook>().AsSingle();
        Container.BindInterfacesTo<EnvironmentOverrideHook>().AsSingle();
        Container.BindInterfacesTo<DefaultOverrideSettingsPatch>().AsSingle();
    }
}