using NftFaucet.Domain.Models.Abstraction;

namespace NftFaucet.Domain.Services;

public interface ITokenMediaDownloader
{
    public Task<ITokenMedia> Download(Uri location);
}
