using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QopenAPI
{
    public class SearchTrackResult
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

    }
}

