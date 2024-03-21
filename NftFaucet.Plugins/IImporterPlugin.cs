using NftFaucet.Plugins.Models.Abstraction;

namespace NftFaucet.Plugins;

public interface IImporterPlugin
{
    public IReadOnlyCollection<IImporter> Importers { get; }
}
