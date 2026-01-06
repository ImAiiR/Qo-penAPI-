using Newtonsoft.Json;

// https://github.com/DJDoubleD/QobuzApiSharp/tree/master/docs/QobuzApiSharp.Models.Content
namespace QopenAPI
{
    public class ReleaseRights
    {
        [JsonProperty("purchasable")]
        public bool? Purchasable { get; set; }

        [JsonProperty("streamable")]
        public bool? Streamable { get; set; }

        [JsonProperty("downloadable")]
        public bool? Downloadable { get; set; }

        [JsonProperty("hires_streamable")]
        public bool? HiresStreamable { get; set; }

        [JsonProperty("hires_purchasable")]
        public bool? HiresPurchasable { get; set; }
    }
}