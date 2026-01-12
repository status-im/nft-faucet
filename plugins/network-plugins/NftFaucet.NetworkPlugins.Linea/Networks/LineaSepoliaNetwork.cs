using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Linea.Networks;

public sealed class LineaSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("d2e3f4a5-b6c7-4d5e-9f8a-2b3c4d5e6f7a");
    public override string Name { get; } = "Linea Sepolia";
    public override string ShortName { get; } = "LineaSepolia";
    public override ulong? ChainId { get; } = 59141;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "linea-black.svg";
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Linea;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.sepolia.linea.build");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.lineascan.build/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("e2f3a4b5-c6d7-4e5f-9a8b-2c3d4e5f6a7b"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x28124902bdf70c6b21c77f264505923c6c5a8034b7f015d63af1f77918943ff8",
            DeployedAt = DateTime.Parse("Jan-12-2026 01:27:51 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("f2a3b4c5-d6e7-4f5a-9b8c-2d3e4f5a6b7c"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x3f4ddb93e5bbde5cf2c1bba6459cde1594505d69545ebeeaf1895fa343e9ab49",
            DeployedAt = DateTime.Parse("Jan-12-2026 01:32:31 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
