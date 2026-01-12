using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Optimism.Networks;

public sealed class OptimismMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("2fa5b635-6711-4994-9d2a-3ca730176516");
    public override string Name { get; } = "Optimism";
    public override string ShortName { get; } = "Optimism";
    public override ulong? ChainId { get; } = 10;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "optimism.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Optimism;
    public override Uri PublicRpcUrl { get; } = new Uri("https://mainnet.optimism.io");
    public override Uri ExplorerUrl { get; } = new Uri("https://optimistic.etherscan.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("2a54a5b3-8f9e-4758-ab44-bbb3499f3f89"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa1E277eA6b97eFfc5b61B3BF5dE03F438981247E",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x2ddf42ca4d41b7683e45bd96d4b80bd80fc34644b396e07351bb764ea144a77e",
            DeployedAt = DateTime.Parse("Jul-23-2024 12:43:17 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("7fb321dd-6f70-4038-8ad0-f13817ff3fc7"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x9e467ab3a2ffdc5646ad6d20208f5efaf72f2821",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xfecc3645046d987aadf3be1a28a2d9aebf176531cc8d2e6a6480bc498bf93c22",
            DeployedAt = DateTime.Parse("Jul-23-2024 12:27:39 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
