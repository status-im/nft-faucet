using NftFaucet.Plugins;
using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.ImportPlugins.OpenSea;

public class OpenSeaImporterPlugin : IImporterPlugin
{
    public IReadOnlyCollection<IImporter> Importers { get; } = new[]
    {
        new OpenSeaImporter(),
    };
}
