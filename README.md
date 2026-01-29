# NFT Faucet
[![Deploy to GitHub Pages](https://github.com/status-im/nft-faucet/actions/workflows/main.yml/badge.svg?branch=main)](https://github.com/status-im/nft-faucet/actions/workflows/main.yml)

It's a WASM web-application that allows you to mint ERC-721 and ERC-1155 tokens to any specified address from supported networks.

## Demo
Go to https://status-im.github.io/nft-faucet

[![demo](demo2.gif)]()

## Deployed contracts
Used [contracts](NftFaucet/Contracts) are based on [OpenZeppilin contracts](https://github.com/OpenZeppelin/openzeppelin-contracts), but with one unusual feature - `mint` method can be called by anyone, not just by an owner.

|                 | ERC-721   | ERC-1155   |
|-----------------|-----------|------------|
| Ropsten         | [0x71902F99902339d7ce1F994C12155f4350BCD226](https://ropsten.etherscan.io/token/0x71902F99902339d7ce1F994C12155f4350BCD226) | [0x80b45421881c0452A6e70148Fc928fA33107cEb3](https://ropsten.etherscan.io/token/0x80b45421881c0452A6e70148Fc928fA33107cEb3) |
| Rinkeby         | [0x9F64932Be34D5D897C4253D17707b50921f372B6](https://rinkeby.etherscan.io/token/0x9F64932Be34D5D897C4253D17707b50921f372B6) | [0xf67C575502fc1cE399a3e1895dDf41847185D7bD](https://rinkeby.etherscan.io/token/0xf67C575502fc1cE399a3e1895dDf41847185D7bD) |
| Goerli          | [0xC3E4214dd442136079dF06bb2529Bae276d37564](https://goerli.etherscan.io/token/0xC3E4214dd442136079dF06bb2529Bae276d37564) | [0x5807d7be82153F6a302d92199221090E3b78A3C3](https://goerli.etherscan.io/token/0x5807d7be82153F6a302d92199221090E3b78A3C3) |
| Kovan           | [0x99ea658e02baDE18c43Af5Fa8c18cfF4f251E311](https://kovan.etherscan.io/token/0x99ea658e02baDE18c43Af5Fa8c18cfF4f251E311) | [0xdBDD0377D1799910A4B0a4306F8d812265bF33Cb](https://kovan.etherscan.io/token/0xdBDD0377D1799910A4B0a4306F8d812265bF33Cb) |
| Sepolia		  | [0x9F64932Be34D5D897C4253D17707b50921f372B6](https://sepolia.etherscan.io/token/0x9F64932Be34D5D897C4253D17707b50921f372B6) | [0x1eD60FedfF775D500DDe21A974cd4E92e0047Cc8](https://sepolia.etherscan.io/token/0x1eD60FedfF775D500DDe21A974cd4E92e0047Cc8) |
| Optimism        | [0xC72986988ff5fFBFb8e4dbbAd293d106c4DB8D0C](https://optimistic.etherscan.io/token/0xc72986988ff5ffbfb8e4dbbad293d106c4db8d0c) | [0x9e467AB3a2fFDc5646AD6d20208f5eFAf72f2821](https://optimistic.etherscan.io/token/0x9e467ab3a2ffdc5646ad6d20208f5efaf72f2821) |
| OptimismKovan   | [0xee52f32f4bbcedc2a1ed1c195936132937f2d371](https://kovan-optimistic.etherscan.io/token/0xee52f32f4bbcedc2a1ed1c195936132937f2d371) | [0xCc0040129f197F63D37ebd77E62a6F96dDcd4e0A](https://kovan-optimistic.etherscan.io/token/0xCc0040129f197F63D37ebd77E62a6F96dDcd4e0A) |
| OptimismSepolia   | [0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54](https://sepolia-optimism.etherscan.io/token/0xa7df1338ade48bcdc4194929b9853a2f9516bf54) | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://sepolia-optimism.etherscan.io/token/0x1fbaab49e7e3228b1f265ce894c5537434e7468b) |
| PolygonMumbai   | [0xeE8272220A0988279627714144Ff6981E204fbE4](https://mumbai.polygonscan.com/token/0xeE8272220A0988279627714144Ff6981E204fbE4) | [0x23147CdbD963A3D0fec0F25E4604844f477F65d2](https://mumbai.polygonscan.com/token/0x23147CdbD963A3D0fec0F25E4604844f477F65d2) |
| MoonbaseAlpha   | [0x9F64932Be34D5D897C4253D17707b50921f372B6](https://moonbase.moonscan.io/token/0x9F64932Be34D5D897C4253D17707b50921f372B6) | [0xf67C575502fc1cE399a3e1895dDf41847185D7bD](https://moonbase.moonscan.io/token/0xf67C575502fc1cE399a3e1895dDf41847185D7bD) |
| Arbitrum        | [0xE818108e360d659F5c487bBf01EC0F519432e5e5](https://arbiscan.io/token/0xE818108e360d659F5c487bBf01EC0F519432e5e5) | [0x23C3080e0B5d0109ad7330A1A65d3b015Bc24cb2](https://arbiscan.io/token/0x23C3080e0B5d0109ad7330A1A65d3b015Bc24cb2) |
| ArbitrumRinkeby | [0x9F64932Be34D5D897C4253D17707b50921f372B6](https://testnet.arbiscan.io/token/0x9F64932Be34D5D897C4253D17707b50921f372B6) | [0xf67C575502fc1cE399a3e1895dDf41847185D7bD](https://testnet.arbiscan.io/token/0xf67C575502fc1cE399a3e1895dDf41847185D7bD) |
| ArbitrumSepolia   | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://sepolia.arbiscan.io/token/0x1fbaab49e7e3228b1f265ce894c5537434e7468b) | [0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54](https://sepolia.arbiscan.io/token/0xa7df1338ade48bcdc4194929b9853a2f9516bf54) |
| AvalancheFuji   | [0x9F64932Be34D5D897C4253D17707b50921f372B6](https://testnet.snowtrace.io/token/0x9F64932Be34D5D897C4253D17707b50921f372B6) | [0xf67C575502fc1cE399a3e1895dDf41847185D7bD](https://testnet.snowtrace.io/token/0xf67C575502fc1cE399a3e1895dDf41847185D7bD) |
| BnbChainTestnet | [0xe6ee919a81da4dad1e632614ba4fdb8d748eb278](https://testnet.bscscan.com/token/0xe6ee919a81da4dad1e632614ba4fdb8d748eb278) | [0xa6d787d1ec987a96ba2a8bf4dae79234e4a2125a](https://testnet.bscscan.com/token/0xa6d787d1ec987a96ba2a8bf4dae79234e4a2125a) |
| Base        | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://basescan.org/token/0x1Fbaab49e7E3228B1F265CE894c5537434E7468b) | [0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c](https://basescan.org/token/0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c) |
| BaseSepolia   | [0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54](https://sepolia.basescan.org/token/0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54) | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://sepolia.basescan.org/token/0x1Fbaab49e7E3228B1F265CE894c5537434E7468b) |
| StatusNetworkSepolia   | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://sepoliascan.status.network/address/0x1Fbaab49e7E3228B1F265CE894c5537434E7468b) | [0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c](https://sepoliascan.status.network/address/0xfC43ac5f309499385e91e059862bDb0Bfa2Cd16c) |
| Linea   | [0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54](https://lineascan.build/address/0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54) | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://lineascan.build/address/0x1Fbaab49e7E3228B1F265CE894c5537434E7468b) |
| Linea Sepolia  | [0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54](https://sepolia.lineascan.build/address/0xa7DF1338aDE48bcDc4194929B9853a2F9516BF54) | [0x1Fbaab49e7E3228B1F265CE894c5537434E7468b](https://sepolia.lineascan.build/address/0x1Fbaab49e7E3228B1F265CE894c5537434E7468b) |
| Unichain Sepolia  | [0x2Ae0c0417aA9E0CD380EC243FcE5d0823f60f758](https://unichain-sepolia.blockscout.com/address/0x2Ae0c0417aA9E0CD380EC243FcE5d0823f60f758) | [0x2D7367F3E507f9f4a115E755AFaCbB368A5Fa176](https://unichain-sepolia.blockscout.com/address/0x2D7367F3E507f9f4a115E755AFaCbB368A5Fa176) |
| Ink Sepolia  | [0x044A7F8241486322993cD1482560bEeE1833BC09](https://explorer-sepolia.inkonchain.com/address/0x044A7F8241486322993cD1482560bEeE1833BC09) | [0x3D1b7622c28011A171489756C6eA9BA4cC25F750](https://explorer-sepolia.inkonchain.com/address/0x3D1b7622c28011A171489756C6eA9BA4cC25F750) |
| Polygon zkEVM Cardona  | [0x044A7F8241486322993cD1482560bEeE1833BC09](https://explorer.zkevm-testnet.com/address/0x044A7F8241486322993cD1482560bEeE1833BC09) | [0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46](https://explorer.zkevm-testnet.com/address/0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46) |
| Katana Bokuto  | [0xa12923e5cc51c3af4dfef75ee915eda62aab4a46](https://bokuto.katanascan.com/address/0xa12923e5cc51c3af4dfef75ee915eda62aab4a46) | [0x044a7f8241486322993cd1482560beee1833bc09](https://bokuto.katanascan.com/address/0x044a7f8241486322993cd1482560beee1833bc09) |
| Abstract Testnet  | [0xa12923e5cc51c3af4dfef75ee915eda62aab4a46](https://sepolia.abscan.org/address/0xa12923e5cc51c3af4dfef75ee915eda62aab4a46) | [0x044a7f8241486322993cd1482560beee1833bc09](https://sepolia.abscan.org/address/0x044a7f8241486322993cd1482560beee1833bc09) |
| zkSync Sepolia  | [0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46](https://sepolia.explorer.zksync.io/address/0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46) | [0x044a7f8241486322993cd1482560beee1833bc09](https://sepolia.explorer.zksync.io/address/0x044a7f8241486322993cd1482560beee1833bc09) |
| Soneium Minato  | [0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46](https://soneium-minato.blockscout.com/address/0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46) | [0x044a7f8241486322993cd1482560beee1833bc09](https://soneium-minato.blockscout.com/address/0x044a7f8241486322993cd1482560beee1833bc09) |
| Scroll Sepolia  | [0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46](https://sepolia.scrollscan.com/address/0xa12923E5cc51C3Af4dfeF75ee915edA62Aab4A46) | [0x044a7f8241486322993cd1482560beee1833bc09](https://sepolia.scrollscan.com/address/0x044a7f8241486322993cd1482560beee1833bc09) |

## Technology stack

NOTE: The entire web app works as a static website, hosted on Github Pages. There is NO backend, it runs only in your browser! :)

- Blazor WASM
- Metamask
- IPFS (upload provider - Infura, pinning provider - Crust)
- Solidity smart contracts

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com) [![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

## How to run it locally?
Simply type this command in the root of this repo:

    dotnet run --project NftFaucet
