using System.Text;
using CSharpFunctionalExtensions;
using MimeTypes;
using NftFaucet.Components;
using NftFaucet.Components.CardList;
using NftFaucet.Domain.Models;
using NftFaucet.Domain.Models.Abstraction;
using NftFaucet.Domain.Services;
using NftFaucet.Domain.Utils;
using NftFaucet.Plugins.Models;
using NftFaucet.Plugins.Models.Abstraction;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace NftFaucet.Pages;

public partial class CreateTokenDialog : BasicComponent
{
    [Inject] public ITokenMetadataGenerator TokenMetadataGenerator { get; set; }

    private NewFileModel Model { get; set; } = new NewFileModel();
    private bool ModelIsValid => IsValid() && SelectedUploader != null && SelectedUploader.IsConfigured;
    private bool IsUploading { get; set; }

    // Uploader selection
    private CardListItem[] UploaderCards { get; set; }
    private Guid[] SelectedUploaderIds { get; set; }
    private IUploader SelectedUploader => AppState?.PluginStorage?.Uploaders?.FirstOrDefault(x => x.Id == SelectedUploaderIds?.FirstOrDefault());

    protected override void OnInitialized()
    {
        base.OnInitialized();
        RefreshCards();
    }

    private async Task OnSavePressed()
    {
        if (!IsValid() || SelectedUploader == null || !SelectedUploader.IsConfigured)
            return;

        IsUploading = true;
        RefreshMediator.NotifyStateHasChangedSafe();

        var token = new Token
        {
            Id = Guid.NewGuid(),
            Name = Model.Name,
            Description = Model.Description,
            CreatedAt = DateTime.Now,
            MainFile = new TokenMedia
            {
                FileName = Model.MainFileName,
                FileType = DetermineFileType(Model.MainFileName),
                FileData = Model.MainFileData,
                FileSize = Model.MainFileSize!.Value,
            },
        };

        if (!string.IsNullOrEmpty(Model.CoverFileData) &&
            !string.IsNullOrEmpty(Model.CoverFileName) &&
            Model.CoverFileSize != null)
        {
            token.CoverFile = new TokenMedia
            {
                FileName = Model.CoverFileName,
                FileType = DetermineFileType(Model.CoverFileName),
                FileData = Model.CoverFileData,
                FileSize = Model.CoverFileSize!.Value,
            };
        }

        // Upload files and metadata to IPFS
        var uploadResult = await UploadTokenMetadata(token);
        if (uploadResult.IsFailure)
        {
            IsUploading = false;
            RefreshMediator.NotifyStateHasChangedSafe();
            NotificationService.Notify(NotificationSeverity.Error, "Upload failed", uploadResult.Error);
            return;
        }

        token.Location = uploadResult.Value;
        IsUploading = false;
        RefreshMediator.NotifyStateHasChangedSafe();
        NotificationService.Notify(NotificationSeverity.Success, "Token created and uploaded", uploadResult.Value);
        DialogService.Close(token);
    }

    private async Task<Result<string>> UploadTokenMetadata(Token token)
    {
        // Upload main file
        var mainFileLocationResult = await ResultWrapper.Wrap(() =>
            SelectedUploader.Upload(token.MainFile.FileName, token.MainFile.FileType, Base64DataToBytes(token.MainFile.FileData)));

        if (mainFileLocationResult.IsFailure)
            return Result.Failure<string>($"Failed to upload main file: {mainFileLocationResult.Error}");

        var mainFileLocation = mainFileLocationResult.Value;

        // Upload cover file if exists
        Uri coverFileLocation = null;
        if (token.CoverFile != null)
        {
            var coverFileLocationResult = await ResultWrapper.Wrap(() =>
                SelectedUploader.Upload(token.CoverFile.FileName, token.CoverFile.FileType, Base64DataToBytes(token.CoverFile.FileData)));

            if (coverFileLocationResult.IsFailure)
                return Result.Failure<string>($"Failed to upload cover file: {coverFileLocationResult.Error}");

            coverFileLocation = coverFileLocationResult.Value;
        }

        // Generate and upload metadata
        var tokenMetadata = TokenMetadataGenerator.GenerateTokenMetadata(token, mainFileLocation, coverFileLocation);
        var tokenMetadataBytes = Encoding.UTF8.GetBytes(tokenMetadata);
        var tokenLocationResult = await ResultWrapper.Wrap(() =>
            SelectedUploader.Upload($"{token.Id}.json", "application/json", tokenMetadataBytes));

        if (tokenLocationResult.IsFailure)
            return Result.Failure<string>($"Failed to upload metadata: {tokenLocationResult.Error}");

        return Result.Success(tokenLocationResult.Value.OriginalString);
    }

    private void RefreshCards()
    {
        UploaderCards = AppState.PluginStorage.Uploaders.OrderBy(x => x.Order ?? int.MaxValue).Select(MapCardListItem).ToArray();
        RefreshMediator.NotifyStateHasChangedSafe();
    }

    private CardListItem MapCardListItem(IUploader model)
    {
        var configurationItems = model.GetConfigurationItems();
        return new CardListItem
        {
            Id = model.Id,
            ImageLocation = model.ImageName != null ? "./images/" + model.ImageName : null,
            Header = model.Name,
            Properties = model.GetProperties().Select(Map).ToArray(),
            IsDisabled = !model.IsSupported,
            SelectionIcon = model.IsConfigured ? CardListItemSelectionIcon.Checkmark : CardListItemSelectionIcon.Warning,
            Badges = new[]
            {
                (Settings?.RecommendedUploaders?.Contains(model.Id) ?? false)
                    ? new CardListItemBadge {Style = BadgeStyle.Success, Text = "Recommended"}
                    : null,
                !model.IsSupported ? new CardListItemBadge { Style = BadgeStyle.Light, Text = "Not Supported" } : null,
                model.IsDeprecated ? new CardListItemBadge { Style = BadgeStyle.Warning, Text = "Deprecated" } : null,
            }.Where(x => x != null).ToArray(),
            Buttons = configurationItems != null && configurationItems.Any()
                ? new[]
                {
                    new CardListItemButton
                    {
                        Icon = "build",
                        Style = ButtonStyle.Secondary,
                        Action = async () =>
                        {
                            var result = await OpenConfigurationDialog(model);
                            RefreshCards();
                            if (result.IsSuccess)
                            {
                                await StateRepository.SaveUploaderState(model);
                            }
                        }
                    }
                }
                : Array.Empty<CardListItemButton>(),
        };
    }

    private async Task<Result> OpenConfigurationDialog(IUploader uploader)
    {
        var configurationItems = uploader.GetConfigurationItems();
        foreach (var configurationItem in configurationItems)
        {
            var prevClickHandler = configurationItem.ClickAction;
            if (prevClickHandler != null)
            {
                configurationItem.ClickAction = () =>
                {
                    prevClickHandler();
                    RefreshMediator.NotifyStateHasChangedSafe();
                };
            }
        }

        var result = (bool?) await DialogService.OpenAsync<ConfigurationDialog>("Configuration",
            new Dictionary<string, object>
            {
                { nameof(ConfigurationDialog.ConfigurationItems), configurationItems },
                { nameof(ConfigurationDialog.ConfigureAction), new Func<ConfigurationItem[], Task<Result>>(uploader.Configure) },
            },
            new DialogOptions() {Width = "700px", Height = "570px", Resizable = true, Draggable = true});

        return result != null && result.Value ? Result.Success() : Result.Failure("Operation cancelled");
    }

    private static byte[] Base64DataToBytes(string fileData)
    {
        var index = fileData.IndexOf(';');
        var encoded = fileData.Substring(index + 8);
        return Convert.FromBase64String(encoded);
    }

    private CardListItemProperty Map(Property model)
        => model == null ? null : new CardListItemProperty
        {
            Name = model.Name,
            Value = model.Value,
            ValueColor = model.ValueColor,
            Link = model.Link,
        };

    private string DetermineFileType(string fileName)
    {
        var extension = fileName.Split('.', StringSplitOptions.RemoveEmptyEntries).Last();
        if (!MimeTypeMap.TryGetMimeType(extension, out var mimeType))
        {
            return "application/octet-stream";
        }

        return mimeType;
    }

    private bool IsValid()
    {
        if (string.IsNullOrWhiteSpace(Model.Name))
            return false;

        if (string.IsNullOrWhiteSpace(Model.Description))
            return false;

        if (string.IsNullOrEmpty(Model.MainFileData))
            return false;

        if (string.IsNullOrEmpty(Model.MainFileName))
            return false;

        if (Model.MainFileSize is null or 0)
            return false;

        return true;
    }

    private void OnMainFileError(UploadErrorEventArgs args)
    {
        NotificationService.Notify(NotificationSeverity.Error, "File selection error", args.Message);
        Model.MainFileData = null;
        Model.MainFileName = null;
        Model.MainFileSize = null;
        Model.CoverFileData = null;
        Model.CoverFileName = null;
        Model.CoverFileSize = null;
    }

    private void OnCoverFileError(UploadErrorEventArgs args)
    {
        NotificationService.Notify(NotificationSeverity.Error, "File selection error", args.Message);
        Model.CoverFileData = null;
        Model.CoverFileName = null;
        Model.CoverFileSize = null;
    }

    private class NewFileModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainFileData { get; set; }
        public string MainFileName { get; set; }
        public long? MainFileSize { get; set; }
        public string CoverFileData { get; set; }
        public string CoverFileName { get; set; }
        public long? CoverFileSize { get; set; }
    }
}
