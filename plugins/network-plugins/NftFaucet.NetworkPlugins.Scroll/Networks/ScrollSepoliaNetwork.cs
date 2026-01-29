using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Scroll.Networks;

public sealed class ScrollSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef");
    public override string Name { get; } = "Scroll Sepolia";
    public override string ShortName { get; } = "ScrollSepolia";
    public override ulong? ChainId { get; } = 534351;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "scroll-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Scroll;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia-rpc.scroll.io");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia.scrollscan.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("b2c3d4e5-f678-9012-3456-7890abcdef12"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0xba009ec9525b43fdf2524551e93e8adaa74a5a50b58d429e0c2e014cefe4c744",
            DeployedAt = DateTime.Parse("Jan-29-2026 01:31:26 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("c3d4e5f6-7890-1234-5678-90abcdef1234"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x044a7f8241486322993cd1482560beee1833bc09",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xcfdcc60054fd7ec513ccea5122ea997452de7a274c2f27a124d15ce6f54e85f8",
            DeployedAt = DateTime.Parse("Jan-29-2026 01:31:53 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
