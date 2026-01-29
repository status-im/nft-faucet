using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Katana.Networks;

public sealed class KatanaBokutoNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("4f5a6b7c-8d9e-4a5b-9c6d-7e8f9a0b1c2d");
    public override string Name { get; } = "Katana Bokuto";
    public override string ShortName { get; } = "KatanaBokuto";
    public override ulong? ChainId { get; } = 737373;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "katana-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Katana;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc-bokuto.katanarpc.com");
    public override Uri ExplorerUrl { get; } = new Uri("https://bokuto.katanascan.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("3e4f5a6b-7c8d-4e5f-9a6b-7c8d9e0f1a2b"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa12923e5cc51c3af4dfef75ee915eda62aab4a46",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x22c81bd4d9a64f873e3cb5afda129bf29fb7f8daf19ac0f82609506e376b51f4",
            DeployedAt = DateTime.Parse("Jan-29-2026 10:21:41 AM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("4f5a6b7c-8d9e-4f5a-9b6c-7d8e9f0a1b2c"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x044a7f8241486322993cd1482560beee1833bc09",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xe18b548f5caf6c6ac39aaf39b45e556809d3301add4425857a9058cf3b2635b3",
            DeployedAt = DateTime.Parse("Jan-29-2026 10:43:16 AM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
