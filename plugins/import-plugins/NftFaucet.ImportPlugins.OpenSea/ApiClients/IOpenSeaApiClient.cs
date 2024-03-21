using System.ComponentModel.DataAnnotations;
using System.Numerics;
using NftFaucet.ImportPlugins.OpenSea.Models;
using RestEase;

namespace NftFaucet.ImportPlugins.OpenSea.ApiClients;

public enum Chains
{
    [Display(Name = "arbitrum")]
    Arbitrum = 42161,

    [Display(Name = "arbitrum_sepolia")]
    ArbitrumSepolia = 421614,

    [Display(Name = "ethereum")]
    Ethereum = 1,

    [Display(Name = "ethereum_sepolia")]
    EthereumSepolia = 11155111,

    [Display(Name = "optimism")]
    Optimism = 10,

    [Display(Name = "optimism_sepolia")]
    OptimismSepolia = 11155420,
}

[BasePath("/api/v2")]
public interface IOpenSeaApiClient
{
    [Header("x-api-key")]
    public string Auth { get; set; }

    [Get("chain/{chain}/contract/{address}/nfts/{tokenId}")]
    [AllowAnyStatusCode]
    Task<Response<GetNFTResponse>> GetNFT([Path(PathSerializationMethod.Serialized)] Chains chain, [Path] string address, [Path] BigInteger tokenId);
}
