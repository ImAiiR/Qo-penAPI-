using Newtonsoft.Json;
using System;

// https://github.com/DJDoubleD/QobuzApiSharp/tree/master/docs/QobuzApiSharp.Models.Content
namespace QopenAPI
{
    public class ReleaseDates
    {
        [JsonProperty("download")]
        public DateTimeOffset? Download { get; set; }

        [JsonProperty("original")]
        public DateTimeOffset? Original { get; set; }

        [JsonProperty("stream")]
        public DateTimeOffset? Stream { get; set; }
    }
}