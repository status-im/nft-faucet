using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Infrastructure.Models.Dto;
using NftFaucet.Infrastructure.Models.State;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.Infrastructure.Repositories;

public interface IStateRepository
{
    public Task SaveAppState(ScopedAppState appState);
    public Task SaveToken(IToken token);
    public Task SaveWalletState(IWallet wallet);
    public Task SaveUploaderState(IUploader uploader);
    public Task SaveImporterState(IImporter importer);

    public Task LoadAppState(ScopedAppState appState);
    public Task<IToken[]> LoadTokens();
    public Task<UploaderStateDto[]> LoadUploaderStates();
    public Task<WalletStateDto[]> LoadWalletStates();
    public Task<ImporterStateDto[]> LoadImporterStates();

    public Task DeleteToken(Guid tokenId);
}
