using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Base.Networks;

public sealed class BaseSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("d1e2f3a4-b5c6-4d5e-8f9a-0b1c2d3e4f5a");
    public override string Name { get; } = "Base Sepolia";
    public override string ShortName { get; } = "BaseSepolia";
    public override ulong? ChainId { get; } = 84532;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "base-black.svg";
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Base;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia.base.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.basescan.org/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("e1f2a3b4-c5d6-4e5f-8a9b-0c1d2e3f4a5b"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0xd0595c80dd38c2a42f5853d29c4694de74bcb205842b603ebbdc8dca17289b8d",
            DeployedAt = DateTime.Parse("Jan-13-2025 06:57:12 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("f1a2b3c4-d5e6-4f5a-8b9c-0d1e2f3a4b5c"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x87b6b84f621bf5b709ba90e940934781609f7c5114bdb73cb14d2832ebf167a5",
            DeployedAt = DateTime.Parse("Jan-13-2025 06:57:38 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
