using NftFaucet.ImportPlugins.OpenSea;
using NftFaucet.NetworkPlugins.Arbitrum;
using NftFaucet.NetworkPlugins.Avalanche;
using NftFaucet.NetworkPlugins.BinanceSmartChain;
using NftFaucet.NetworkPlugins.Ethereum;
using NftFaucet.NetworkPlugins.Moonbeam;
using NftFaucet.NetworkPlugins.Optimism;
using NftFaucet.NetworkPlugins.Polygon;
using NftFaucet.NetworkPlugins.Solana;
using NftFaucet.NetworkPlugins.Base;
using NftFaucet.NetworkPlugins.Linea;
using NftFaucet.NetworkPlugins.StatusNetwork;
using NftFaucet.NetworkPlugins.Unichain;
using NftFaucet.NetworkPlugins.Ink;
using NftFaucet.NetworkPlugins.PolygonZkEvm;
using NftFaucet.NetworkPlugins.Katana;
using NftFaucet.NetworkPlugins.Abstract;
using NftFaucet.NetworkPlugins.ZkSync;
using NftFaucet.NetworkPlugins.Soneium;
using NftFaucet.NetworkPlugins.Scroll;
using NftFaucet.Plugins;
using NftFaucet.WalletPlugins.Keygens;
using NftFaucet.WalletPlugins.Metamask;
using NftFaucet.WalletPlugins.Phantom;
using NftFaucet.UploadPlugins.Crust;
using NftFaucet.UploadPlugins.Infura;
using NftFaucet.UploadPlugins.NftStorage;

namespace NftFaucet.Services;

public class PluginLoader
{
    public IReadOnlyCollection<INetworkPlugin> NetworkPlugins { get; } = new INetworkPlugin[]
    {
        new EthereumNetworkPlugin(),
        new PolygonNetworkPlugin(),
        new BscNetworkPlugin(),
        new OptimismNetworkPlugin(),
        new MoonbeamNetworkPlugin(),
        new ArbitrumNetworkPlugin(),
        new AvalancheNetworkPlugin(),
        new SolanaNetworkPlugin(),
        new BaseNetworkPlugin(),
        new LineaNetworkPlugin(),
        new StatusNetworkPlugin(),
        new UnichainNetworkPlugin(),
        new InkNetworkPlugin(),
        new PolygonZkEvmNetworkPlugin(),
        new KatanaNetworkPlugin(),
        new AbstractNetworkPlugin(),
        new ZkSyncNetworkPlugin(),
        new SoneiumNetworkPlugin(),
        new ScrollNetworkPlugin(),
    };

    public IReadOnlyCollection<IWalletPlugin> WalletPlugins { get; } = new IWalletPlugin[]
    {
        new MetamaskWalletPlugin(),
        new PhantomWalletPlugin(),
        new KeygenWalletPlugin(),
    };

    public IReadOnlyCollection<IUploaderPlugin> UploaderPlugins { get; } = new IUploaderPlugin[]
    {
        new InfuraUploaderPlugin(),
        new NftStorageUploaderPlugin(),
        new CrustUploaderPlugin(),
    };

    public IReadOnlyCollection<IImporterPlugin> ImporterPlugins { get; } = new IImporterPlugin[]
    {
        new OpenSeaImporterPlugin(),
    };
}
