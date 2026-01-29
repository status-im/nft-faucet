using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Ink.Networks;

public sealed class InkMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("c42d4b5b-2c4a-4d39-a0db-42b0b0e9f213");
    public override string Name { get; } = "Ink";
    public override string ShortName { get; } = "Ink";
    public override ulong? ChainId { get; } = 57073;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "ink.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Ink;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc-gel.inkonchain.com");
    public override Uri ExplorerUrl { get; } = new Uri("https://explorer.inkonchain.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("6c5a02a4-9a38-4a55-bd21-f5b0dbfd0c9e"),
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
            Id = Guid.Parse("1adf0f78-1490-4d6a-bd02-78be8c9b5944"),
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

