using System.Numerics;
using NftFaucet.Domain.Models.Abstraction;

namespace NftFaucet.Plugins.Models.Abstraction;

public interface IImporter : INamedEntity, IEntityWithOrder, IStateful, IInitializable, IEntityWithProperties, IConfigurable
{
    public Task<IToken> Import(ulong chainId, string contractAddress, BigInteger tokenId);
    public bool IsChainIDSupported(ulong chainId);
}
