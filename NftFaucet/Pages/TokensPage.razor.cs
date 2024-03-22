using ByteSizeLib;
using NftFaucet.Components;
using NftFaucet.Components.CardList;
using NftFaucet.Domain.Models.Abstraction;
using Radzen;

namespace NftFaucet.Pages;

public partial class TokensPage : BasicComponent
{
    protected override void OnInitialized()
    {
        RefreshCards();
        base.OnInitialized();
    }

    private CardListItem[] TokenCards { get; set; }

    private void RefreshCards()
    {
        TokenCards = AppState?.UserStorage?.Tokens?.Select(MapCardListItem).ToArray() ?? Array.Empty<CardListItem>();
    }

    private CardListItem MapCardListItem(IToken token)
    {
        var properties = new List<CardListItemProperty>
        {
            new CardListItemProperty
            {
                Name = "Description",
                Value = token.Description,
            },
        };
        properties.Add(new CardListItemProperty
        {
            Name = token.CoverFile == null ? "Size" : "MF Size",
            Value = ByteSize.FromBytes(token.MainFile.FileSize).ToString(),
        });
        if (token.CoverFile != null)
        {
            properties.Add(new CardListItemProperty
            {
                Name = "CF Size",
                Value = ByteSize.FromBytes(token.CoverFile.FileSize).ToString(),
            });
        }
        return new CardListItem
        {
            Id = token.Id,
            Header = token.Name,
            ImageLocation = token.CoverFile?.FileData ?? token.MainFile.FileData,
            Properties = properties.ToArray(),
            ContextMenuButtons = new []
            {
                new CardListItemButton
                {
                    Name = "Delete",
                    Action = async () => await DeleteToken(token),
                },
            },
        };
    }

    private async Task OpenCreateTokenDialog()
    {
        var token = (IToken) await DialogService.OpenAsync<CreateTokenDialog>("Create new token",
            new Dictionary<string, object>(),
            new DialogOptions() { Width = "700px", Height = "570px", Resizable = true, Draggable = true });

        if (token == null)
        {
            return;
        }

        AppState.UserStorage.Tokens ??= new List<IToken>();
        AppState.UserStorage.Tokens.Add(token);
        AppState.UserStorage.SelectedTokens = new[] { token.Id };
        AppState.UserStorage.SelectedUploadLocations = Array.Empty<Guid>();
        RefreshCards();
        RefreshMediator.NotifyStateHasChangedSafe();
        await StateRepository.SaveToken(token);
        await SaveAppState();
    }

    private async Task OpenImportTokenDialog()
    {
        var token = (IToken) await DialogService.OpenAsync<ImportTokenDialog>("Import token",
            new Dictionary<string, object>(),
            new DialogOptions() { Width = "1000px", Height = "700px", Resizable = true, Draggable = true });
 
        if (token == null)
        {
            return;
        }

        AppState.UserStorage.Tokens ??= new List<IToken>();
        AppState.UserStorage.Tokens.Add(token);
        AppState.UserStorage.SelectedTokens = new[] { token.Id };
        AppState.UserStorage.SelectedUploadLocations = Array.Empty<Guid>();
        RefreshCards();
        RefreshMediator.NotifyStateHasChangedSafe();
        await StateRepository.SaveToken(token);
        await SaveAppState();
    }

    private async Task OnTokenChange()
    {
        AppState.UserStorage.SelectedUploadLocations = Array.Empty<Guid>();
        await SaveAppState();
    }

    private async Task DeleteToken(IToken token)
    {
        var tokenLocations = AppState?.UserStorage?.UploadLocations?.Where(x => x.TokenId == token.Id).ToArray() ?? Array.Empty<ITokenUploadLocation>();
        foreach (var tokenUploadLocation in tokenLocations)
        {
            await StateRepository.DeleteTokenLocation(tokenUploadLocation.Id);
        }

        await StateRepository.DeleteToken(token.Id);

        AppState!.UserStorage!.UploadLocations = AppState.UserStorage.UploadLocations!.Except(tokenLocations).ToList();
        AppState!.UserStorage!.Tokens = AppState.UserStorage.Tokens!.Where(x => x.Id != token.Id).ToList();
        RefreshCards();
        RefreshMediator.NotifyStateHasChangedSafe();
    }
}
