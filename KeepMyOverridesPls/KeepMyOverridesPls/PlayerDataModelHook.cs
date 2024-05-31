using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;
using Zenject;

namespace KeepMyOverridesPls
{
    // override environment settings are not saved when the game reloads so they will be saved and loaded from the config
    internal class PlayerDataModelHook : IInitializable, IAffinity
    {
        private readonly PluginConfig config;
        private readonly OverrideEnvironmentSettings overrideEnvironmentSettings;
        private readonly EnvironmentsListModel environmentsListModel;

        private PlayerDataModelHook(PluginConfig config, PlayerDataModel playerDataModel, EnvironmentsListModel environmentsListModel)
        {
            this.config = config;
            this.environmentsListModel = environmentsListModel;
            overrideEnvironmentSettings = playerDataModel.playerData.overrideEnvironmentSettings;
        }

        public void Initialize()
        {
            SetEnvInfoForType(EnvironmentType.Normal, config.NormalEnvironment);
            SetEnvInfoForType(EnvironmentType.Circle, config.CircleEnvironment);
        }

        private void SetEnvInfoForType(EnvironmentType type, string serializedName) =>
            overrideEnvironmentSettings.SetEnvironmentInfoForType(type, environmentsListModel.GetEnvironmentInfoBySerializedName(serializedName));
    }
}
