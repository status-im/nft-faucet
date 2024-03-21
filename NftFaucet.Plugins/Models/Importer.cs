using System.Numerics;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.Plugins.Models;

public abstract class Importer : DefaultEntity, IImporter
{
    public abstract Task<IToken> Import(ulong chainId, string contractAddress, BigInteger tokenId);
    public abstract bool IsChainIDSupported(ulong chainId);
}
