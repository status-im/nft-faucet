using System.Net.Http;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;

namespace NftFaucet.Domain.Services;

public class TokenMediaDownloader : ITokenMediaDownloader
{
    public async Task<ITokenMedia> Download(Uri location)
    {   
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(location);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"TokenMediaDownloader Status: {(int) response.StatusCode}. Reason: {response.ReasonPhrase}");
        }

        var fileData = await response.Content.ReadAsByteArrayAsync();
        var fileName = location.Segments[^1];
        var fileType = response.Content.Headers.ContentType.MediaType;
        var fileSize = fileData.Length;
        return new TokenMedia
        {
            FileName = fileName,
            FileType = fileType,
            FileData = $"data:{fileType};base64,{Convert.ToBase64String(fileData)}",
            FileSize = fileSize,
        };
    }
}
