using NftFaucet.NetworkPlugins.ZkSync.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.ZkSync;

public class ZkSyncNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new ZkSyncMainnetNetwork(),
        new ZkSyncSepoliaNetwork(),
    };
}
