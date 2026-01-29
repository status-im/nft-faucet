using NftFaucet.NetworkPlugins.Katana.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Katana;

public class KatanaNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new KatanaMainnetNetwork(),
        new KatanaBokutoNetwork(),
    };
}
