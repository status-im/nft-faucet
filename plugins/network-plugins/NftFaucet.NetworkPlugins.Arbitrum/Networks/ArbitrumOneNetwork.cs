using System.Globalization;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models.Enums;
using NftFaucet.Plugins.Models;

namespace NftFaucet.NetworkPlugins.Arbitrum.Networks;

public sealed class ArbitrumOneNetwork : Network
{
    public override Guid Id { get; } = Guid.Parse("4f0be8b9-dda1-4598-88b9-d4ba77f4c30e");
    public override string Name { get; } = "Arbitrum One";
    public override string ShortName { get; } = "Arbitrum";
    public override ulong? ChainId { get; } = 42161;
    public override int? Order { get; } = 1;
    public override string MainCurrency { get; } = "ETH";
    public override string SmallestCurrency { get; } = "wei";
    public override string ImageName { get; } = "arbitrum.svg";
    public override bool IsSupported { get; } = true;
    public override bool IsTestnet { get; } = false;
    public override NetworkType Type { get; } = NetworkType.Ethereum;
    public override NetworkSubtype SubType { get; } = NetworkSubtype.Arbitrum;
    public override Uri PublicRpcUrl { get; } = new Uri("https://arb1.arbitrum.io/rpc");
    public override Uri ExplorerUrl { get; } = new Uri("https://arbiscan.io/");

    public override IReadOnlyCollection<IContract> DeployedContracts { get; } = new[]
    {
        new Contract
        {
            Id = Guid.Parse("434bf3d5-94fa-4165-9da2-b54787279312"),
            Name = "ERC-721 Faucet",
            Symbol = "FA721",
            Address = "0xe818108e360d659f5c487bbf01ec0f519432e5e5",
            Type = ContractType.Erc721,
            DeploymentTxHash = "0xf30473047f9f3b50bb5295b0c5178213a5817902c974b5c7544b04eeff7f9a21",
            DeployedAt = DateTime.Parse("Jul-23-2024 12:40:58 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
        new Contract
        {
            Id = Guid.Parse("ceae5ad1-6b9e-45f4-950e-823930c6ba24"),
            Name = "ERC-1155 Faucet",
            Symbol = "FA1155",
            Address = "0xa1E277eA6b97eFfc5b61B3BF5dE03F438981247E",
            Type = ContractType.Erc1155,
            DeploymentTxHash = "0x0d0277df473e7aab1e58dd9dd65505aa53a7473f55e56f9f1bff8843b469f448",
            DeployedAt = DateTime.Parse("Jul-23-2024 12:33:29 PM", CultureInfo.InvariantCulture),
            IsVerified = true,
            MinBalanceRequired = 50000000000000,
        },
    };
}
