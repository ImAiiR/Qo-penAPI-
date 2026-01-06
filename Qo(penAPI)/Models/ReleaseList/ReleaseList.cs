using Newtonsoft.Json;
using System.Collections.Generic;

// https://github.com/DJDoubleD/QobuzApiSharp/tree/master/docs/QobuzApiSharp.Models.Content
namespace QopenAPI
{
    public class ReleasesList
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("items")]
        public List<Release> Items { get; set; }
    }
}