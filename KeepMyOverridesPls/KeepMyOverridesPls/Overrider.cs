using KeepMyOverridesPls.Configuration;
using Zenject;

namespace KeepMyOverridesPls;

internal class Overrider : IInitializable
{
    private readonly PluginConfig config;
    private readonly OverrideEnvironmentSettings overrideEnvironmentSettings;
    private readonly EnvironmentsListModel environmentsListModel;

    public Overrider(
        PluginConfig config,
        PlayerDataModel playerDataModel,
        EnvironmentsListModel environmentsListModel)
    {
        this.config = config;
        overrideEnvironmentSettings = playerDataModel.playerData.overrideEnvironmentSettings;
        this.environmentsListModel = environmentsListModel;
    }

    public void Initialize()
    {
        overrideEnvironmentSettings.overrideEnvironments = config.OverrideEnvironments;
        SetEnvInfoForType(EnvironmentType.Normal, config.NormalEnvironment);
        SetEnvInfoForType(EnvironmentType.Circle, config.CircleEnvironment);
    }

    private void SetEnvInfoForType(EnvironmentType type, string serializedName)
    {
        var envInfo = environmentsListModel.GetEnvironmentInfoBySerializedName(serializedName);
        overrideEnvironmentSettings.SetEnvironmentInfoForType(type, envInfo);
    }
}