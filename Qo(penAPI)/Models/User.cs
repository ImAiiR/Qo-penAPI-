using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace QopenAPI
{
    public class User
    {
        [JsonProperty("user_auth_token")]
        public string UserAuthToken { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("user")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("publicId")]
        public string PublicId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

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

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }

        [JsonProperty("last_update")]
        public LastUpdate LastUpdate { get; set; }

        [JsonProperty("player_settings")]
        public JToken PlayerSettings { get; set; }

        [JsonProperty("externals")]
        public Externals Externals { get; set; }

        [JsonProperty("credential")]
        public Credential Credential { get; set; }
    }

    public class Credential
    {
        [JsonProperty("id")]
        public object Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public object Label { get; set; }

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

        [JsonProperty("hfp_purchase")]
        public bool HfpPurchase { get; set; }

        [JsonProperty("included_format_group_ids")]
        public List<int> IncludedFormatGroupIds { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("short_label")]
        public string ShortLabel { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("color_scheme")]
        public ColorScheme ColorScheme { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("offer")]
        public string Offer { get; set; }

        [JsonProperty("periodicity")]
        public string Periodicity { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("is_canceled")]
        public bool IsCanceled { get; set; }
    }

    public class LastUpdate
    {
        [JsonProperty("favorite")]
        public int Favorite { get; set; }

        [JsonProperty("playlist")]
        public int Playlist { get; set; }

        [JsonProperty("purchase")]
        public int Purchase { get; set; }
    }

    public class PlayerSettings
    {
        [JsonProperty("sonos_audio_format")]
        public int SonosAudioFormat { get; set; }
    }

    public class ColorScheme
    {
        [JsonProperty("logo")]
        public string Logo { get; set; }
    }

    public class Externals
    {
    }
}

