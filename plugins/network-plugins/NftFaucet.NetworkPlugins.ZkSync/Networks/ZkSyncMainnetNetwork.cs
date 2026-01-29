using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.ZkSync.Networks;

public sealed class ZkSyncMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a");
    public override string Name { get; } = "zkSync";
    public override string ShortName { get; } = "ZkSync";
    public override ulong? ChainId { get; } = 324;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "zksync.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.ZkSync;
    public override Uri PublicRpcUrl { get; } = new Uri("https://mainnet.era.zksync.io");
    public override Uri ExplorerUrl { get; } = new Uri("https://explorer.zksync.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"),
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
            Id = Guid.Parse("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f9a0b1c"),
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
