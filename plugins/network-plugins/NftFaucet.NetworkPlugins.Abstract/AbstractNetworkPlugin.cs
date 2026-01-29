using NftFaucet.NetworkPlugins.Abstract.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Abstract;

public class AbstractNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new AbstractMainnetNetwork(),
        new AbstractTestnetNetwork(),
    };
}
