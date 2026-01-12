using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Base.Networks;

public sealed class BaseMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d");
    public override string Name { get; } = "Base";
    public override string ShortName { get; } = "Base";
    public override ulong? ChainId { get; } = 8453;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "base.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Base;
    public override Uri PublicRpcUrl { get; } = new Uri("https://mainnet.base.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://basescan.org/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("b1c2d3e4-f5a6-4b5c-8d9e-0f1a2b3c4d5e"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x104f06f0b3d6a21de63544fe7595a4656b1f95f11a90456b1f2f53d5919e2c3a",
            DeployedAt = DateTime.Parse("Jan-13-2025 06:56:05 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("c1d2e3f4-a5b6-4c5d-8e9f-0a1b2c3d4e5f"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xb99680f61a97c72f266fef865e2b7e808b005e0118c7bb946d20ad2deaab7bce",
            DeployedAt = DateTime.Parse("Jan-13-2025 06:58:15 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
