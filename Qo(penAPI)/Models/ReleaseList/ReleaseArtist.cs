using Newtonsoft.Json;

// https://github.com/DJDoubleD/QobuzApiSharp/tree/master/docs/QobuzApiSharp.Models.Content
namespace QopenAPI
{
    public class ReleaseArtist
    {
        [JsonProperty("name")]
        public ReleaseArtistName Name { get; set; }
    }

    public class ReleaseArtistName
    {
        [JsonProperty("display")]
        public string Display { get; set; }
    }
}