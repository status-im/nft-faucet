using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Katana.Networks;

public sealed class KatanaMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("d571c263-8f0d-4412-9056-7c4526ecf0b0");
    public override string Name { get; } = "Katana";
    public override string ShortName { get; } = "Katana";
    public override ulong? ChainId { get; } = 747474;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "katana.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Katana;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.katana.network");
    public override Uri ExplorerUrl { get; } = new Uri("https://katanascan.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("30dd5218-c2f5-4a88-928e-07dc0af2b4ff"),
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
            Id = Guid.Parse("2d5e64b4-de17-4ad8-8eb8-de89b5ef84bf"),
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
