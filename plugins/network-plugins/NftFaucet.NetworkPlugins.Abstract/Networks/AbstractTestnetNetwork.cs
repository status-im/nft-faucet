using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Abstract.Networks;

public sealed class AbstractTestnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("5a6b7c8d-9e0f-4a5b-8c6d-9e0f1a2b3c4d");
    public override string Name { get; } = "Abstract Testnet";
    public override string ShortName { get; } = "AbstractTestnet";
    public override ulong? ChainId { get; } = 11124;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "abstract-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Abstract;
    public override Uri PublicRpcUrl { get; } = new Uri("https://abstract-sepolia.drpc.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.abscan.org/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("6b7c8d9e-0f1a-4b5c-9d6e-0f1a2b3c4d5e"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa12923e5cc51c3af4dfef75ee915eda62aab4a46",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x31e03228de0a7a22dbc4870d2ad99722a8cd81446a4753883ed98dfedd164431",
            DeployedAt = DateTime.Parse("Jan-29-2026 12:10:02 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("7c8d9e0f-1a2b-4c5d-9e6f-1a2b3c4d5e6f"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x044a7f8241486322993cd1482560beee1833bc09",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x91c041007e48c64f60a0d1a349609f4f2291cc99ee358b1579176a6433ce2306",
            DeployedAt = DateTime.Parse("Jan-29-2026 12:13:23 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
