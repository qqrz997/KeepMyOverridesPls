using KeepMyOverridesPls.Configuration;
using KeepMyOverridesPls.Patches;
using Zenject;

namespace KeepMyOverridesPls.Installers
{
    internal class AppInstaller(PluginConfig config) : Installer
    {
        private readonly PluginConfig config = config;

        public override void InstallBindings()
        {
            Container.BindInstance(config).AsSingle();
            Container.BindInterfacesTo<PlayerDataModelHook>().AsSingle();

            // Patches
            Container.BindInterfacesTo<MainFlowCoordinatorPatch>().AsSingle();
            Container.BindInterfacesTo<OverrideEnvironmentSettingsPatch>().AsSingle();
            Container.BindInterfacesTo<EnvironmentOverrideSettingsPanelControllerPatch>().AsSingle();
        }
    }
}
