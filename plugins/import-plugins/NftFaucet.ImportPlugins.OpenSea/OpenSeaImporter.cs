using System.Numerics;
using CSharpFunctionalExtensions;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Services;
using NftFaucet.Plugins.Models;
using NftFaucet.Plugins.Models.Enums;
using NftFaucet.ImportPlugins.OpenSea.ApiClients;
using RestEase;

namespace NftFaucet.ImportPlugins.OpenSea;

public class OpenSeaImporter : Importer
{
    public override Guid Id { get; } = Guid.Parse("6e0c96e5-7810-4e15-80c0-bfdb21813220");
    public override string Name { get; } = "opensea";
    public override string ShortName { get; } = "OpenSea";
    public override string ImageName { get; } = "opensea.svg";
    public override bool IsConfigured { get; protected set; }

    public override int? Order { get; } = 1;

    private string ApiKey { get; set; }

    public override Property[] GetProperties()
        => new Property[]
        {
            IsConfigured
                ? new Property {Name = "Configured", Value = "YES", ValueColor = "green"}
                : new Property {Name = "Configured", Value = "NO", ValueColor = "red"}
        };

    public override ConfigurationItem[] GetConfigurationItems()
    {
        var instructionsText = new ConfigurationItem
        {
            DisplayType = UiDisplayType.Text,
            Name = "Instructions",
            Value = "Go to 'https://docs.opensea.io/reference/api-keys', follow instructions to create API key and copy it",
        };
        var apiKeyInput = new ConfigurationItem
        {
            DisplayType = UiDisplayType.Input,
            Name = "API Key",
            Placeholder = "<OpenSea token>",
            Value = ApiKey,
        };
        return new[] { instructionsText, apiKeyInput };
    }

    public override async Task<Result> Configure(ConfigurationItem[] configurationItems)
    {
        var apiKey = configurationItems[1].Value;

        if (string.IsNullOrEmpty(apiKey))
        {
            return Result.Failure("API key is null or empty");
        }

        var apiClient = GetApiClient(Chains.Ethereum, apiKey);
        // Get first Cryptokitty to test API key
        using var testResponse = await apiClient.GetNFT(Chains.Ethereum, "0x06012c8cf97bead5deae237070f9587f8e7a266d", new BigInteger(1));
        if (!testResponse.ResponseMessage.IsSuccessStatusCode)
        {
            return Result.Failure<Uri>($"Status: {(int) testResponse.ResponseMessage.StatusCode}. Reason: {testResponse.ResponseMessage.ReasonPhrase}");
        }

        ApiKey = apiKey;
        IsConfigured = true;
        return Result.Success();
    }

    public override async Task<IToken> Import(ulong chainId, string contractAddress, BigInteger tokenId)
    {
        var chain = (Chains) chainId;
        var apiClient = GetApiClient(chain, ApiKey) ?? throw new Exception("Unsupported chain");
        using var response = await apiClient.GetNFT(chain, contractAddress, tokenId);
        if (!response.ResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception($"Status: {(int) response.ResponseMessage.StatusCode}. Reason: {response.ResponseMessage.ReasonPhrase}");
        }
        var getNFTResponse = response.GetContent();
        if (getNFTResponse == null || getNFTResponse.nft == null || string.IsNullOrEmpty(getNFTResponse.nft.identifier))
        {
            throw new Exception($"Unexpected response: {response.StringContent}");
        }

        var nft = getNFTResponse.nft;

        var downloader = new TokenMediaDownloader();

        var token = new Token
        {
            Name = nft.name,
            Description = nft.description,
            ImporterId = Id,
            Location = nft.metadata_url,
        };

        var imageUrls = new List<string> { nft.animation_url, nft.image_url };

        foreach (var imageUrl in imageUrls)
        {
            if (string.IsNullOrEmpty(imageUrl))
                continue;

            try
            {
                var file = await downloader.Download(new Uri(imageUrl));
                if (file != null) {
                    token.MainFile = file;
                    break;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error downloading media: {imageUrl}, {e.Message}");
            }
        }

        return token;
    }
    public override bool IsChainIDSupported(ulong chainId)
    {
        var chain = (Chains) chainId;
        return chain switch
        {
            Chains.Ethereum => true,
            Chains.Optimism => true,
            Chains.Arbitrum => true,
            Chains.EthereumSepolia => true,
            Chains.OptimismSepolia => true,
            Chains.ArbitrumSepolia => true,
            _ => false
        };
    }

    public override Task<string> GetState()
        => Task.FromResult(ApiKey);

    public override Task SetState(string state)
    {
        if (string.IsNullOrEmpty(state))
            return Task.CompletedTask;

        ApiKey = state;
        IsConfigured = true;
        return Task.CompletedTask;
    }

    private static IOpenSeaApiClient GetApiClient(Chains chain, string apiKey)
    {
        switch (chain) {
            case Chains.EthereumSepolia:
            case Chains.OptimismSepolia:
            case Chains.ArbitrumSepolia: {
                var importClient = new RestClient("https://testnets-api.opensea.io")
                {
                    RequestPathParamSerializer = new StringEnumRequestPathParamSerializer(),
                }.For<IOpenSeaApiClient>();
                
                return importClient;
            }
            case Chains.Ethereum:
            case Chains.Optimism:
            case Chains.Arbitrum: {
                var importClient = new RestClient("https://api.opensea.io")
                {
                    RequestPathParamSerializer = new StringEnumRequestPathParamSerializer(),
                }.For<IOpenSeaApiClient>();
                importClient.Auth = apiKey;

                return importClient;
            }
        }
        return null;
    }
}
