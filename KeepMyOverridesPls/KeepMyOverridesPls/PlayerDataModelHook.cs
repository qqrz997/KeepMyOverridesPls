using KeepMyOverridesPls.Configuration;
using SiraUtil.Affinity;
using Zenject;

namespace KeepMyOverridesPls
{
    // override environment settings are not saved when the game reloads so they will be saved and loaded from the config
    internal class PlayerDataModelHook(PluginConfig config, PlayerDataModel playerDataModel, EnvironmentsListModel environmentsListModel) : IInitializable, IAffinity
    {
        private readonly PluginConfig config = config;
        private readonly OverrideEnvironmentSettings overrideEnvironmentSettings = playerDataModel.playerData.overrideEnvironmentSettings;
        private readonly EnvironmentsListModel environmentsListModel = environmentsListModel;

        public void Initialize()
        {
            SetEnvInfoForType(EnvironmentType.Normal, config.NormalEnvironment);
            SetEnvInfoForType(EnvironmentType.Circle, config.CircleEnvironment);
        }

        private void SetEnvInfoForType(EnvironmentType type, string serializedName) =>
            overrideEnvironmentSettings.SetEnvironmentInfoForType(type, environmentsListModel.GetEnvironmentInfoBySerializedName(serializedName));
    }
}
