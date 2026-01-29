using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Scroll.Networks;

public sealed class ScrollMainnetNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("d4e5f678-9012-3456-7890-abcdef123456");
    public override string Name { get; } = "Scroll";
    public override string ShortName { get; } = "Scroll";
    public override ulong? ChainId { get; } = 534352;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "scroll.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Scroll;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.scroll.io");
    public override Uri ExplorerUrl { get; } = new Uri("https://scrollscan.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("e5f67890-1234-5678-90ab-cdef12345678"),
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
            Id = Guid.Parse("f6789012-3456-7890-abcd-ef1234567890"),
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
