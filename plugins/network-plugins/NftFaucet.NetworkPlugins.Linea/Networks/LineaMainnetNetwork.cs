using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Linea.Networks;

public sealed class LineaMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("a2b3c4d5-e6f7-4a5b-9c8d-2e3f4a5b6c7d");
    public override string Name { get; } = "Linea";
    public override string ShortName { get; } = "Linea";
    public override ulong? ChainId { get; } = 59144;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "linea.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Linea;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.linea.build");
    public override Uri ExplorerUrl { get; } = new Uri("https://lineascan.build/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("b2c3d4e5-f6a7-4b5c-9d8e-2f3a4b5c6d7e"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x2cabc71204cd191cc916f8555dea9ee942e728dea65add7960d8d9059efab98b",
            DeployedAt = DateTime.Parse("Jan-12-2026 02:10:02 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("c2d3e4f5-a6b7-4c5d-9e8f-2a3b4c5d6e7f"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x4078dc0b7049561e3a49717a67a3fda492c9a38333bd1cfc72f776a35806651e",
            DeployedAt = DateTime.Parse("Jan-12-2026 02:11:50 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
