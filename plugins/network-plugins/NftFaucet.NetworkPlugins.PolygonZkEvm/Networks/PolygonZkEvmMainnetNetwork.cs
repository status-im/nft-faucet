using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.PolygonZkEvm.Networks;

public sealed class PolygonZkEvmMainnetNetwork : Network
{
    // generate a new guid
    public override Guid Id { get; } = Guid.Parse("63af3cd1-595d-44de-bc48-5dcb1b04608d");
    public override string Name { get; } = "Polygon zkEVM";
    public override string ShortName { get; } = "PolygonZkEvm";
    public override ulong? ChainId { get; } = 1101;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "polygon-zkevm.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.PolygonZkEvm;
    public override Uri PublicRpcUrl { get; } = new Uri("https://zkevm-rpc.com");
    public override Uri ExplorerUrl { get; } = new Uri("https://www.oklink.com/polygon-zkevm/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("5e370575-aef8-4033-bd3a-c07993a33dd1"),
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
            Id = Guid.Parse("cbda4099-f64d-4c05-a739-192677a88b0e"),
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
