using NftFaucet.NetworkPlugins.StatusNetwork.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.StatusNetwork;

public class StatusNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new StatusNetworkSepoliaNetwork(),
    };
}
