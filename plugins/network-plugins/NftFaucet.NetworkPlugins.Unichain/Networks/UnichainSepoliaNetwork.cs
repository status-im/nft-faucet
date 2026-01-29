using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Unichain.Networks;

public sealed class UnichainSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("38a6d9a7-1647-4d18-93a7-4c9d4a02106f");
    public override string Name { get; } = "Unichain Sepolia";
    public override string ShortName { get; } = "UniSepolia";
    public override ulong? ChainId { get; } = 1301;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "unichain-black.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Unichain;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia.unichain.org");
    public override Uri ExplorerUrl { get; } = new Uri("https://unichain-sepolia.blockscout.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("1a9da5a2-0a87-49f4-b67b-6d986d5ed4c7"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x2Ae0c0417aA9E0CD380EC243FcE5d0823f60f758",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x809e61776087e3f51ea58d01612abdc668ed640f396129285b32dc63bf4a4425",
            DeployedAt = DateTime.Parse("Jan-22-2026 13:52:55 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("9b0fbde6-1b9c-4a07-ae15-1d1c1d00a64e"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x2D7367F3E507f9f4a115E755AFaCbB368A5Fa176",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x404ea5f096373718d77ba1faf1dc85404aad9f0a00a4badf195a9b69b4b4b6b1",
            DeployedAt = DateTime.Parse("Jan-22-2026 14:24:23 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}

