using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.StatusNetwork.Networks;

public sealed class StatusNetworkSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("a1b2c3d4-e5f6-4a5b-9c8d-1e2f3a4b5c6d");
    public override string Name { get; } = "Status Network Sepolia";
    public override string ShortName { get; } = "StatusSepolia";
    public override ulong? ChainId { get; } = 1660990954;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "status-black.png";
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.StatusNetwork;
    public override Uri PublicRpcUrl { get; } = new Uri("https://public.sepolia.rpc.status.network");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepoliascan.status.network/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("b1c2d3e4-f5a6-4b5c-9d8e-1f2a3b4c5d6e"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x6ee92a96351ad706ff865f45d35736ae8af3a99997a2dfb06771b344306af94f",
            DeployedAt = DateTime.Parse("Mar-25-2025 01:17:47 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("c1d2e3f4-a5b6-4c5d-9e8f-1a2b3c4d5e6f"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xd8d101f305ac88a102cd2b8e72ffc13af41541883841daddd7ce7cac8035e4e6",
            DeployedAt = DateTime.Parse("Mar-25-2025 01:18:11 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
