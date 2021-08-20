using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class Session
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("infos")]
        public string Infos { get; set; }

        [JsonProperty("expires_at")]
        public int ExpiresAt { get; set; }
    }
}

