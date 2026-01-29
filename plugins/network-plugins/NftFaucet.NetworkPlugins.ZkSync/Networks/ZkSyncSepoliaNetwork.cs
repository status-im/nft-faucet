using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.ZkSync.Networks;

public sealed class ZkSyncSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("1a190a5c-26c8-4ae1-baee-be531202e962");
    public override string Name { get; } = "zkSync Sepolia";
    public override string ShortName { get; } = "ZkSyncSepolia";
    public override ulong? ChainId { get; } = 300;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "zksync-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.ZkSync;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia.era.zksync.dev");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.explorer.zksync.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("df91775b-a63c-42af-92f3-c0de2773221d"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x76a78aa12bc6c03330b2d30da1a3150a123d301d6f9e9769d8f244893248459a",
            DeployedAt = DateTime.Parse("Jan-29-2026 14:02:00 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("34617743-8ab3-4689-b7c1-50c734bc2512"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x044a7f8241486322993cd1482560beee1833bc09",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x2880243a170bcd0618560f462c94a9210704a7b3148083c74594368deea0b175",
            DeployedAt = DateTime.Parse("Jan-29-2026 14:07:00 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
