using Ethereum.MetaMask.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NftFaucet.Options;
using NftFaucet.Services;
using NftFaucet;
using NftFaucet.Domain.Services;
using NftFaucet.Infrastructure.Models.State;
using NftFaucet.Infrastructure.Repositories;
using NftFaucet.Infrastructure.Services;
using Radzen;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var settings = new Settings();
builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings);

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddSingleton<PluginLoader>();
builder.Services.AddSingleton<Mapper>();
builder.Services.AddScoped<ITokenMetadataGenerator, TokenMetadataGenerator>();
builder.Services.AddScoped<IInitializationService, InitializationService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ScopedAppState>();
builder.Services.AddScoped<RefreshMediator>();

// add Radzen components
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

builder.Services.AddMetaMaskBlazor();

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "NftFaucetV2";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "AppState",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "selectedNetwork", KeyPath = "selectedNetwork", Auto = false},
            new IndexSpec {Name = "selectedWallet", KeyPath = "selectedWallet", Auto = false},
            new IndexSpec {Name = "selectedContract", KeyPath = "selectedContract", Auto = false},
            new IndexSpec {Name = "selectedToken", KeyPath = "selectedToken", Auto = false},
            new IndexSpec {Name = "selectedUploadLocation", KeyPath = "selectedUploadLocation", Auto = false},
            new IndexSpec {Name = "destinationAddress", KeyPath = "destinationAddress", Auto = false},
            new IndexSpec {Name = "tokenAmount", KeyPath = "tokenAmount", Auto = false},
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "Tokens",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "name", KeyPath = "name", Auto = false},
            new IndexSpec {Name = "description", KeyPath = "description", Auto = false},
            new IndexSpec {Name = "createdAt", KeyPath = "createdAt", Auto = false},
            new IndexSpec {Name = "mainFileName", KeyPath = "mainFileName", Auto = false},
            new IndexSpec {Name = "mainFileType", KeyPath = "mainFileType", Auto = false},
            new IndexSpec {Name = "mainFileData", KeyPath = "mainFileData", Auto = false},
            new IndexSpec {Name = "mainFileSize", KeyPath = "mainFileSize", Auto = false},
            new IndexSpec {Name = "coverFileName", KeyPath = "coverFileName", Auto = false},
            new IndexSpec {Name = "coverFileType", KeyPath = "coverFileType", Auto = false},
            new IndexSpec {Name = "coverFileData", KeyPath = "coverFileData", Auto = false},
            new IndexSpec {Name = "coverFileSize", KeyPath = "coverFileSize", Auto = false},
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "UploadLocations",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "tokenId", KeyPath = "tokenId", Auto = false},
            new IndexSpec {Name = "name", KeyPath = "name", Auto = false},
            new IndexSpec {Name = "location", KeyPath = "location", Auto = false},
            new IndexSpec {Name = "createdAt", KeyPath = "createdAt", Auto = false},
            new IndexSpec {Name = "uploaderId", KeyPath = "uploaderId", Auto = false},
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "WalletStates",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "state", KeyPath = "state", Auto = false},
        }
    });

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "UploaderStates",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "state", KeyPath = "state", Auto = false},
        }
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IndexedDBManager>();
    await db.AddNewStore(new StoreSchema
    {
        Name = "ImporterStates",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            new IndexSpec {Name = "state", KeyPath = "state", Auto = false},
        }
    });
}

var initializationService = app.Services.GetRequiredService<IInitializationService>();
await initializationService.Initialize();
await app.RunAsync();
