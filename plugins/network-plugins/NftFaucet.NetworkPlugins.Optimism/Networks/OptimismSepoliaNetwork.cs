using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Optimism.Networks;

public sealed class OptimismSepoliaNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("24a46bde-4d06-4ff3-ae69-9b302ed5f31f");
    public override string Name { get; } = "Optimism Sepolia";
    public override string ShortName { get; } = "OpSepolia";
    public override ulong? ChainId { get; } = 11155420;
    public override int? Order { get; } = 4;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "optimism-black.svg";
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Optimism;
    public override Uri PublicRpcUrl { get; } = new Uri("https://sepolia.optimism.io");
    public override Uri ExplorerUrl { get; } = new Uri("https://sepolia-optimism.etherscan.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("d417bf45-dc23-4bd1-a038-71c8c936bd18"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0x4933b66c41f47f1c64b6d767401e44cd6e4bf142d540a8f676c57d1eb8418738",
            DeployedAt = DateTime.Parse("Mar-13-2024 05:58:26 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("fe34c710-cd8d-4bac-8da0-ae832ec0fee8"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0x1Fbaab49e7E3228B1F265CE894c5537434E7468b",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x4b4663597543d41c0af9f9f014b598e6c0a8718c8f35e2b074ebb517357b5bc9",
            DeployedAt = DateTime.Parse("Mar-13-2024 05:59:18 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
