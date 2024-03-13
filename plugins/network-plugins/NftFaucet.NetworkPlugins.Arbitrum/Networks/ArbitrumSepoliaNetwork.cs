using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Arbitrum.Networks;

public sealed class ArbitrumSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("707e99a4-45af-4642-b7a8-b2908b8bed72");
    public override string Name { get; } = "Arbitrum Sepolia";
    public override string ShortName { get; } = "ArbSepolia";
    public override ulong? ChainId { get; } = 421614;
    public override int? Order { get; } = 4;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "arbitrum-black.svg";
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Arbitrum;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia-rollup.arbitrum.io/rpc");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.arbiscan.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("b7d73acc-0fdf-4367-88c2-a58c498c54de"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x4665a6e35c739678387b3814624d1092b4f47b290b312a00c319fb302169e818",
            DeployedAt = DateTime.Parse("Mar-13-2024 05:57:47 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("a7b5b5a5-053c-49c5-9258-4d211d1e751b"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x3f150cafaa822da77c785b2ad85d0286ba3781e09b592172e8a55e7c32e3da69",
            DeployedAt = DateTime.Parse("Mar-13-2024 05:57:10 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
