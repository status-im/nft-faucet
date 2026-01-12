using NftFaucet.NetworkPlugins.Linea.Networks;
using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.NetworkPlugins.Linea;

public class LineaNetworkPlugin : INetworkPlugin
{
    public IReadOnlyCollection<INetwork> Networks { get; } = new INetwork[]
    {
        new LineaMainnetNetwork(),
        new LineaSepoliaNetwork(),
    };
}
