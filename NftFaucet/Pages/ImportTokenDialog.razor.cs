using System.Numerics;
using CSharpFunctionalExtensions;
using Nethereum.Util;
using NftFaucet.Components;
using NftFaucet.Components.CardList;
using NftFaucet.Domain.Utils;
using NftFaucet.Plugins.Models;
using NftFaucet.Plugins.Models.Abstraction;
using Radzen;

#pragma warning disable CS8974

namespace NftFaucet.Pages;

public partial class ImportTokenDialog : BasicComponent
{
    private TokenModel Model { get; set; } = new TokenModel();
    private bool ModelIsValid => IsValid();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        RefreshCards();
    }

    private CardListItem[] ImporterCards { get; set; }
    private Guid[] SelectedImporterIds { get; set; }
    private IImporter SelectedImporter => AppState?.PluginStorage?.Importers?.FirstOrDefault(x => x.Id == SelectedImporterIds?.FirstOrDefault());
    private bool IsImporting { get; set; }

    private void RefreshCards()
    {
        ImporterCards = AppState.PluginStorage.Importers.OrderBy(x => x.Order ?? int.MaxValue).Select(MapCardListItem).ToArray();
        RefreshMediator.NotifyStateHasChangedSafe();
    }

    private CardListItem MapCardListItem(IImporter model)
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
                                await StateRepository.SaveImporterState(model);
                            }
                        }
                    }
                }
                : Array.Empty<CardListItemButton>(),
        };
    }

    private List<INetwork> SupportedNetworks => AppState.PluginStorage.Networks.Where(x => SelectedImporter?.IsChainIDSupported(x.ChainId ?? 0) ?? false).ToList();

    private async Task OnImportPressed()
    {
        if (!IsValid())
            return;

        IsImporting = true;
        RefreshMediator.NotifyStateHasChangedSafe();

        var importResult = await ResultWrapper.Wrap(() => SelectedImporter.Import(Model.ChainId, Model.ContractAddress, BigInteger.Parse(Model.TokenId)));

        IsImporting = false;
        RefreshMediator.NotifyStateHasChangedSafe();

        if (importResult.IsFailure)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Failed to import token", importResult.Error);
            return;
        }

        DialogService.Close(importResult.Value);
    }

    private async Task<Result> OpenConfigurationDialog(IImporter importer)
    {
        var configurationItems = importer.GetConfigurationItems();
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
                { nameof(ConfigurationDialog.ConfigureAction), importer.Configure },
            },
            new DialogOptions() {Width = "700px", Height = "570px", Resizable = true, Draggable = true});

        return result != null && result.Value ? Result.Success() : Result.Failure("Operation cancelled");
    }

    private CardListItemProperty Map(Property model)
        => model == null ? null : new CardListItemProperty
        {
            Name = model.Name,
            Value = model.Value,
            ValueColor = model.ValueColor,
            Link = model.Link,
        };

    private class TokenModel
    {
        public ulong ChainId { get; set; }
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }
    }

    private bool IsValid()
    {
        if (Model.ChainId == 0)
            return false;

        var addrValidator = new AddressUtil();
        if (!addrValidator.IsValidEthereumAddressHexFormat(Model.ContractAddress))
            return false;

        try {
            var tokenId = BigInteger.Parse(Model.TokenId);
        } catch {
            return false;
        }

        return true;
    }
}
