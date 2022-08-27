using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using NftFaucetRadzen.Components;
using NftFaucetRadzen.Models;
using NftFaucetRadzen.Plugins.NetworkPlugins;
using Radzen;

namespace NftFaucetRadzen.Pages;

public partial class NetworkPage : BasicComponent
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    protected override void OnInitialized()
    {
        Networks = AppState.Storage.Networks
            .GroupBy(x => x.Type)
            .ToDictionary(x => x.Key, x => x.OrderBy(v => v.Order ?? int.MaxValue).Select(MapCardListItem).ToArray());
    }

    private Dictionary<NetworkType, CardListItem[]> Networks { get; set; }

    private static CardListItem MapCardListItem(INetwork model)
        => new CardListItem
        {
            Id = model.Id,
            ImageName = model.ImageName,
            Header = model.Name,
            IsDisabled = !model.IsSupported,
            Properties = new[]
            {
                new CardListItemProperty { Name = "ChainID", Value = model.ChainId?.ToString() },
                new CardListItemProperty { Name = "Currency", Value = model.Currency },
            },
            Badges = new[]
            {
                !model.IsSupported ? new CardListItemBadge { Style = BadgeStyle.Light, Text = "Not Supported" } : null,
                !model.IsTestnet ? new CardListItemBadge { Style = BadgeStyle.Danger, Text = "Mainnet" } : null,
                model.IsDeprecated ? new CardListItemBadge { Style = BadgeStyle.Warning, Text = "Deprecated" } : null,
            }.Where(x => x != null).ToArray(),
        };
}
