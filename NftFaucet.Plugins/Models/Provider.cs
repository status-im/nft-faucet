using NftFaucet.Domain.Models;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.Plugins.Models;

public abstract class Provider : DefaultEntity, IProvider
{
    public abstract bool IsNetworkSupported(INetwork network);
    public abstract Task<string> GetAddress();
    public abstract Task<Balance> GetBalance(INetwork network);
    public abstract Task<INetwork> GetNetwork(IReadOnlyCollection<INetwork> allKnownNetworks, INetwork selectedNetwork);
    public abstract Task<string> Mint(MintRequest mintRequest);
}
