using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Unichain.Networks;

public sealed class UnichainMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("7e2b67c5-67a0-4d7a-a68a-79d1e5f8b4d7");
    public override string Name { get; } = "Unichain";
    public override string ShortName { get; } = "Unichain";
    public override ulong? ChainId { get; } = 130;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "unichain.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Unichain;
    public override Uri PublicRpcUrl { get; } = new Uri("https://mainnet.unichain.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://unichain.blockscout.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("c1b836e8-3f0f-4b7f-8d5b-6ab0567c1df7"),
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
            Id = Guid.Parse("d7dfbff1-0c35-4dd7-a45d-6d3bd2c3d06a"),
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

