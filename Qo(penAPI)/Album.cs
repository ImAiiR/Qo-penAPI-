using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class Album
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("tracks_count")]
        public int TracksCount { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("released_at")]
        public int ReleasedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("qobuz_id")]
        public int QobuzId { get; set; }

        [JsonProperty("upc")]
        public string UPC { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        [JsonProperty("streamable")]
        public bool Streamable { get; set; }

        [JsonProperty("previewable")]
        public bool Previewable { get; set; }

        [JsonProperty("sampleable")]
        public bool Sampleable { get; set; }

        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        [JsonProperty("displayable")]
        public bool Displayable { get; set; }

        [JsonProperty("purchasable_at")]
        public int PurchasableAt { get; set; }

        [JsonProperty("streamable_at")]
        public int StreamableAt { get; set; }

        [JsonProperty("maximum_sampling_rate")]
        public double MaximumSamplingRate { get; set; }

        [JsonProperty("maximum_bit_depth")]
        public int MaximumBitDepth { get; set; }

        [JsonProperty("hires")]
        public bool Hires { get; set; }

    }
}

