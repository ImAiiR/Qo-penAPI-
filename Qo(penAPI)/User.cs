using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }

        [JsonProperty("zone")]
        public string Zone { get; set; }

        [JsonProperty("store")]
        public string Store { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("user_auth_token")]
        public string UserAuthToken { get; set; }
    }

}

