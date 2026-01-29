using NftFaucet.NetworkPlugins.Ink.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Ink;

public class InkNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new InkMainnetNetwork(),
        new InkSepoliaNetwork(),
    };
}

