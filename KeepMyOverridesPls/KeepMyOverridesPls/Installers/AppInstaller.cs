using KeepMyOverridesPls.Configuration;
using KeepMyOverridesPls.Patches;
using Zenject;

namespace KeepMyOverridesPls.Installers
{
    internal class AppInstaller : Installer
    {
        private readonly PluginConfig config;

        private AppInstaller(PluginConfig config) => this.config = config;

        public override void InstallBindings()
        {
            Container.BindInstance(config).AsSingle();
            Container.BindInterfacesTo<PlayerDataModelHook>().AsSingle();

            // Patches
            Container.BindInterfacesTo<MainFlowCoordinatorPatch>().AsSingle();
            Container.BindInterfacesTo<OverrideEnvironmentSettingsPatch>().AsSingle();
        }
    }
}
