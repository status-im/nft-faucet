using NftFaucet.NetworkPlugins.PolygonZkEvm.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.PolygonZkEvm;

public class PolygonZkEvmNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new PolygonZkEvmMainnetNetwork(),
        new PolygonZkEvmCardonaNetwork(),
    };
}
