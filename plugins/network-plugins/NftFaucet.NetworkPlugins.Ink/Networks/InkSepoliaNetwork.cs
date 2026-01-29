using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Ink.Networks;

public sealed class InkSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("2b6d05d9-cf4a-4e3c-9c1e-9475f8c9fca2");
    public override string Name { get; } = "Ink Sepolia";
    public override string ShortName { get; } = "InkSepolia";
    public override ulong? ChainId { get; } = 763373;
    public override int? Order { get; } = 2;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "ink-black.svg";
    public override bool IsTestnet { get; } = true;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Ink;
    public override Uri PublicRpcUrl { get; } = new Uri("https://rpc-gel-sepolia.inkonchain.com");
    public override Uri ExplorerUrl { get; } = new Uri("https://explorer-sepolia.inkonchain.com/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("0d809df4-2f31-481c-b3c8-2a0e2b0cfad4"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0x044A7F8241486322993cD1482560bEeE1833BC09",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x02fcfb09b020e386914569ab1d7ee8c7332512fee1fc89151cf4250e8979153e",
            DeployedAt = DateTime.Parse("Jan-22-2026 14:31:04 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("d9c5c2b6-cf73-4f71-8f70-2fd273e0b2d9"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x3D1b7622c28011A171489756C6eA9BA4cC25F750",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x85ca8ddb8389231d52007cc4e1f8f13f17e7eb5da28c3dd6e654631b6f526169",
            DeployedAt = DateTime.Parse("Jan-22-2026 14:38:16 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}

