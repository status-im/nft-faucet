using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.PolygonZkEvm.Networks;

public sealed class PolygonZkEvmCardonaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("8e7c2d5f-4a3b-4c1e-9d2a-7f8e9a1b2c3d");
    public override string Name { get; } = "Polygon zkEVM Cardona";
    public override string ShortName { get; } = "PolygonZkEvmCardona";
    public override ulong? ChainId { get; } = 2442;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "polygon-zkevm-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.PolygonZkEvm;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.cardona.zkevm-rpc.com");
    public override Uri ExplorerUrl { get; } = new Uri("https://explorer.zkevm-testnet.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x044A7F8241486322993cD1482560bEeE1833BC09",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0xe63de1460ee4ed2b9d567a0170f2f390f4f0094cd6c86cd035d5bfa4275ae2b2",
            DeployedAt = DateTime.Parse("Jan-28-2026 17:17:29 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xfa9aad7c93c5d2a28d022aede53daed413aa6c02732d1f0f10a5e232eb9a352f",
            DeployedAt = DateTime.Parse("Jan-28-2026 16:54:26 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
