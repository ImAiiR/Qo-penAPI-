using Newtonsoft.Json;

// https://github.com/DJDoubleD/QobuzApiSharp/tree/master/docs/QobuzApiSharp.Models.Content
namespace QopenAPI
{
    public class ReleasePhysicalSupport
    {
        [JsonProperty("media_number")]
        public long? MediaNumber { get; set; }

        [JsonProperty("track_number")]
        public long? TrackNumber { get; set; }
    }
}