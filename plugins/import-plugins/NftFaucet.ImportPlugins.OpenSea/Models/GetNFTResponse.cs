namespace NftFaucet.ImportPlugins.OpenSea.Models;

public class GetNFTResponse
{
    public NFT nft { get; set; }

    public class NFT {
        public string identifier { get; set; }
        public string collection { get; set; }
        public string contract { get; set; }
        public string token_standard { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public string metadata_url { get; set; }
        public string opensea_url { get; set; }
        public string updated_at { get; set; }
        public bool is_disabled { get; set; }
        public bool is_nsfw { get; set; }
        public string animation_url { get; set; }
        public bool is_suspicious { get; set; }
        public string creator { get; set; }
    }
}
