using NftFaucet.NetworkPlugins.Base.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Base;

public class BaseNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new BaseMainnetNetwork(),
        new BaseSepoliaNetwork(),
    };
}
