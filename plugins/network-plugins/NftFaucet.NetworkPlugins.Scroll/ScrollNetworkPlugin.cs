using NftFaucet.NetworkPlugins.Scroll.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Scroll;

public class ScrollNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new ScrollMainnetNetwork(),
        new ScrollSepoliaNetwork(),
    };
}
