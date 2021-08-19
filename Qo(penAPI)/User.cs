using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class User
    {
        [JsonProperty("user_auth_token")]
        public string UserAuthToken { get; set; }

        [JsonProperty("user")]
        public UserInfo UserInfo { get; set; }
    }

    public class UserInfo
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

        [JsonProperty("credential")]
        public Credential Credential { get; set; }
    }

    public class Credential
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("parameters")]
        public Parameters Parameters { get; set; }
    }

    public class Parameters
    {
        [JsonProperty("lossy_streaming")]
        public bool LossyStreaming { get; set; }

        [JsonProperty("lossless_streaming")]
        public bool LosslessStreaming { get; set; }

        [JsonProperty("hires_streaming")]
        public bool HiResStreaming { get; set; }

        [JsonProperty("hires_purchases_streaming")]
        public bool HiResPurchasesStreaming { get; set; }

        [JsonProperty("mobile_streaming")]
        public bool MobileStreaming { get; set; }

        [JsonProperty("offline_streaming")]
        public bool OfflineStreaming { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("short_label")]
        public string ShortLabel { get; set; }
    }

}

