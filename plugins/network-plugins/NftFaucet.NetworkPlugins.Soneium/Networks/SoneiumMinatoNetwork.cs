using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Soneium.Networks;

public sealed class SoneiumMinatoNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("7a8b9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d");
    public override string Name { get; } = "Soneium Minato";
    public override string ShortName { get; } = "SoneiumMinato";
    public override ulong? ChainId { get; } = 1946;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "soneium-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Soneium;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc.minato.soneium.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://soneium-minato.blockscout.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("8b9c0d1e-2f3a-4b5c-6d7e-8f9a0b1c2d3e"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x97af87c3ba8e43fa5a22ce3daa1a4ec92b2f4319bf1332a8a56759aa5886f1e5",
            DeployedAt = DateTime.Parse("Jan-29-2026 14:17:16 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("9c0d1e2f-3a4b-5c6d-7e8f-9a0b1c2d3e4f"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x044a7f8241486322993cd1482560beee1833bc09",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0xf86a005d611d5ed858145d30ae95588c3158f12c6ffaccd30e0ce6a0de8c8726",
            DeployedAt = DateTime.Parse("Jan-29-2026 14:18:00 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
