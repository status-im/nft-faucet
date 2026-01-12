using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Infrastructure.Models.Dto;
using NftFaucet.Infrastructure.Models.State;

namespace NftFaucet.Infrastructure.Services;

public class Mapper
{
    public AppStateDto ToDto(ScopedAppState appState)
        => appState == null ? null : new AppStateDto
        {
            SelectedNetwork = appState.SelectedNetwork?.Id,
            SelectedWallet = appState.SelectedWallet?.Id,
            SelectedContract = appState.SelectedContract?.Id,
            SelectedToken = appState.SelectedToken?.Id,
            DestinationAddress = appState.UserStorage?.DestinationAddress,
            TokenAmount = appState.UserStorage?.TokenAmount,
        };

    public TokenDto ToDto(IToken token)
        => token == null ? null : new TokenDto
        {
            Id = token.Id,
            Name = token.Name,
            Description = token.Description,
            CreatedAt = token.CreatedAt,
            MainFileName = token.MainFile?.FileName,
            MainFileType = token.MainFile?.FileType,
            MainFileData = token.MainFile?.FileData,
            MainFileSize = token.MainFile?.FileSize,
            CoverFileName = token.CoverFile?.FileName,
            CoverFileType = token.CoverFile?.FileType,
            CoverFileData = token.CoverFile?.FileData,
            CoverFileSize = token.CoverFile?.FileSize,
            ImporterId = token.ImporterId,
            Location = token.Location,
        };

    public ScopedAppState ToDomain(AppStateDto appStateDto)
        => appStateDto == null ? null : new ScopedAppState
        {
            UserStorage =
            {
                SelectedNetworks = ToGuidArray(appStateDto.SelectedNetwork),
                SelectedWallets = ToGuidArray(appStateDto.SelectedWallet),
                SelectedContracts = ToGuidArray(appStateDto.SelectedContract),
                SelectedTokens = ToGuidArray(appStateDto.SelectedToken),
                DestinationAddress = appStateDto.DestinationAddress,
                TokenAmount = appStateDto.TokenAmount ?? 1,
            }
        };

    public IToken ToDomain(TokenDto tokenDto)
        => tokenDto == null || string.IsNullOrEmpty(tokenDto.MainFileData) ? null : new Token
        {
            Id = tokenDto.Id,
            Name = tokenDto.Name,
            Description = tokenDto.Description,
            CreatedAt = tokenDto.CreatedAt,
            MainFile = new TokenMedia
            {
                FileName = tokenDto.MainFileName,
                FileType = tokenDto.MainFileType,
                FileData = tokenDto.MainFileData,
                FileSize = tokenDto.MainFileSize ?? 0,
            },
            CoverFile = string.IsNullOrEmpty(tokenDto.CoverFileData) ? null : new TokenMedia
            {
                FileName = tokenDto.CoverFileName,
                FileType = tokenDto.CoverFileType,
                FileData = tokenDto.CoverFileData,
                FileSize = tokenDto.CoverFileSize ?? 0,
            },
            ImporterId = tokenDto.ImporterId,
            Location = tokenDto.Location,
        };

    private Guid[] ToGuidArray(Guid? guid) => guid == null ? Array.Empty<Guid>() : new[] {guid.Value};
}
