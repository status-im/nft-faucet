using NftFaucet.NetworkPlugins.Unichain.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Unichain;

public class UnichainNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new UnichainMainnetNetwork(),
        new UnichainSepoliaNetwork(),
    };
}

