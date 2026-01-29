using NftFaucet.NetworkPlugins.Soneium.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Soneium;

public class SoneiumNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new SoneiumMainnetNetwork(),
        new SoneiumMinatoNetwork(),
    };
}
