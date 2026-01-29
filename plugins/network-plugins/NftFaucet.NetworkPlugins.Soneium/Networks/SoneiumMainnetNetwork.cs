using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Soneium.Networks;

public sealed class SoneiumMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("0d1e2f3a-4b5c-6d7e-8f9a-0b1c2d3e4f5a");
    public override string Name { get; } = "Soneium";
    public override string ShortName { get; } = "Soneium";
    public override ulong? ChainId { get; } = 1868;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "soneium.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Soneium;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.soneium.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://soneium.blockscout.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("1e2f3a4b-5c6d-7e8f-9a0b-1c2d3e4f5a6b"),
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
            Id = Guid.Parse("2f3a4b5c-6d7e-8f9a-0b1c-2d3e4f5a6b7c"),
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
