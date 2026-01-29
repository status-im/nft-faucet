using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Abstract.Networks;

public sealed class AbstractMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("8d9e0f1a-2b3c-4d5e-9f6a-2b3c4d5e6f7a");
    public override string Name { get; } = "Abstract";
    public override string ShortName { get; } = "Abstract";
    public override ulong? ChainId { get; } = 2741;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "abstract.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Abstract;
    public override Uri PublicRpcUrl { get; } = new Uri("https://abstract.drpc.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://abscan.org/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("9e0f1a2b-3c4d-5e6f-0a7b-3c4d5e6f7a8b"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = null,
            Type = ContractType.Erc721,
            DeploymentTxHash = null,
            DeployedAt = null,
            IsVerified = false,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("0f1a2b3c-4d5e-6f7a-8b9c-4d5e6f7a8b9c"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = null,
            Type = ContractType.Erc1155,
            DeploymentTxHash = null,
            DeployedAt = null,
            IsVerified = false,
            MinBalanceRequired = 50000000000000,
        },
    };
}
