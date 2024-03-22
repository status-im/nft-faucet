using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Infrastructure.Models.Dto;
using NftFaucet.Infrastructure.Models.State;
using NftFaucet.Infrastructure.Services;
using NftFaucet.Plugins.Models.Abstraction;
using TG.Blazor.IndexedDB;

namespace NftFaucet.Infrastructure.Repositories;

public class StateRepository : IStateRepository
{
    private readonly IndexedDBManager _dbManager;
    private readonly Mapper _mapper;
    private const string AppStateStoreName = "AppState";
    private const string TokensStoreName = "Tokens";
    private const string UploadLocationsStoreName = "UploadLocations";
    private const string WalletStatesStoreName = "WalletStates";
    private const string UploaderStatesStoreName = "UploaderStates";
    private const string ImporterStatesStoreName = "ImporterStates";

    public StateRepository(IndexedDBManager dbManager, Mapper mapper)
    {
        _dbManager = dbManager;
        _mapper = mapper;
    }

    public async Task SaveAppState(ScopedAppState appState)
    {
        var appStateDto = _mapper.ToDto(appState) ?? new AppStateDto();
        var record = new StoreRecord<AppStateDto>
        {
            Storename = AppStateStoreName,
            Data = appStateDto,
        };

        var existingAppStateDto = await GetFirst<AppStateDto>(AppStateStoreName);
        if (existingAppStateDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task LoadAppState(ScopedAppState appState)
    {
        var appStateDto = await GetFirst<AppStateDto>(AppStateStoreName) ?? new AppStateDto();
        var loadedAppState = _mapper.ToDomain(appStateDto);
        appState.LoadUserStorage(loadedAppState.UserStorage);
    }

    public async Task SaveToken(IToken token)
    {
        var tokenDto = _mapper.ToDto(token) ?? new TokenDto();
        var record = new StoreRecord<TokenDto>
        {
            Storename = TokensStoreName,
            Data = tokenDto,
        };

        var existingTokenDto = await _dbManager.GetRecordById<Guid, TokenDto>(TokensStoreName, tokenDto.Id);
        if (existingTokenDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task<IToken[]> LoadTokens()
    {
        var existingTokens = await _dbManager.GetRecords<TokenDto>(TokensStoreName);
        if (existingTokens == null || existingTokens.Count == 0)
            return Array.Empty<IToken>();

        return existingTokens.Select(_mapper.ToDomain).Where(x => x != null).ToArray();
    }

    public async Task SaveUploadLocation(ITokenUploadLocation uploadLocation)
    {
        var uploadLocationDto = _mapper.ToDto(uploadLocation) ?? new UploadLocationDto();
        var record = new StoreRecord<UploadLocationDto>
        {
            Storename = UploadLocationsStoreName,
            Data = uploadLocationDto,
        };

        var existingUploadLocationDto = await _dbManager.GetRecordById<Guid, TokenDto>(UploadLocationsStoreName, uploadLocationDto.Id);
        if (existingUploadLocationDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task<ITokenUploadLocation[]> LoadUploadLocations()
    {
        var existingUploadLocations = await _dbManager.GetRecords<UploadLocationDto>(UploadLocationsStoreName);
        if (existingUploadLocations == null || existingUploadLocations.Count == 0)
            return Array.Empty<ITokenUploadLocation>();

        return existingUploadLocations.Select(_mapper.ToDomain).ToArray();
    }

    public async Task SaveWalletState(IWallet wallet)
    {
        var state = await wallet.GetState();
        var stateDto = new WalletStateDto
        {
            Id = wallet.Id,
            State = state,
        };
        var record = new StoreRecord<WalletStateDto>
        {
            Storename = WalletStatesStoreName,
            Data = stateDto,
        };

        var existingStateDto = await _dbManager.GetRecordById<Guid, WalletStateDto>(WalletStatesStoreName, stateDto.Id);
        if (existingStateDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task<UploaderStateDto[]> LoadUploaderStates()
    {
        var existingUploaderStates = await _dbManager.GetRecords<UploaderStateDto>(UploaderStatesStoreName);
        if (existingUploaderStates == null || existingUploaderStates.Count == 0)
            return Array.Empty<UploaderStateDto>();

        return existingUploaderStates.ToArray();
    }
    
    public async Task SaveUploaderState(IUploader uploader)
    {
        var state = await uploader.GetState();
        var stateDto = new UploaderStateDto
        {
            Id = uploader.Id,
            State = state,
        };
        var record = new StoreRecord<UploaderStateDto>
        {
            Storename = UploaderStatesStoreName,
            Data = stateDto,
        };

        var existingStateDto = await _dbManager.GetRecordById<Guid, UploaderStateDto>(UploaderStatesStoreName, stateDto.Id);
        if (existingStateDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task<ImporterStateDto[]> LoadImporterStates()
    {
        var existingImporterStates = await _dbManager.GetRecords<ImporterStateDto>(ImporterStatesStoreName);
        if (existingImporterStates == null || existingImporterStates.Count == 0)
            return Array.Empty<ImporterStateDto>();

        return existingImporterStates.ToArray();
    }
    
    public async Task SaveImporterState(IImporter importer)
    {
        var state = await importer.GetState();
        var stateDto = new ImporterStateDto
        {
            Id = importer.Id,
            State = state,
        };
        var record = new StoreRecord<ImporterStateDto>
        {
            Storename = ImporterStatesStoreName,
            Data = stateDto,
        };

        var existingStateDto = await _dbManager.GetRecordById<Guid, ImporterStateDto>(ImporterStatesStoreName, stateDto.Id);
        if (existingStateDto == null)
        {
            await _dbManager.AddRecord(record);
        }
        else
        {
            await _dbManager.UpdateRecord(record);
        }
    }

    public async Task<WalletStateDto[]> LoadWalletStates()
    {
        var existingWalletStates = await _dbManager.GetRecords<WalletStateDto>(WalletStatesStoreName);
        if (existingWalletStates == null || existingWalletStates.Count == 0)
            return Array.Empty<WalletStateDto>();

        return existingWalletStates.ToArray();
    }

    public async Task DeleteTokenLocation(Guid uploadLocationId)
    {
        await _dbManager.DeleteRecord(UploadLocationsStoreName, uploadLocationId);
    }

    public async Task DeleteToken(Guid tokenId)
    {
        await _dbManager.DeleteRecord(TokensStoreName, tokenId);
    }

    private async Task<T> GetFirst<T>(string storeName)
    {
        var existingRecords = await _dbManager.GetRecords<T>(storeName);
        if (existingRecords == null || existingRecords.Count == 0)
            return default;

        return existingRecords.FirstOrDefault();
    }
}
