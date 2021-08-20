using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class AppID
    {
        [JsonProperty("app_id")]
        public string App_ID { get; set; }
    }

    public class AppSecret
    {
        [JsonProperty("app_secret")]
        public string App_Secret { get; set; }
    }
    
    public class Playlist
    {
        [JsonProperty("tracks_count")]
        public int TracksCount { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("images150")]
        public List<string> Images150 { get; set; }

        [JsonProperty("is_collaborative")]
        public bool IsCollaborative { get; set; }

        [JsonProperty("images300")]
        public List<string> Images300 { get; set; }

        [JsonProperty("users_count")]
        public int UsersCount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public List<int> Path { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

    }

    public class Owner
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }

    public class Tracks
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

    }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("performers")]
        public string Performers { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("performer")]
        public Performer Performer { get; set; }

        [JsonProperty("composer")]
        public Composer Composer { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("isrc")]
        public string ISRC { get; set; }

        [JsonProperty("audio_info")]
        public AudioInfo AudioInfo { get; set; }

        [JsonProperty("media_number")]
        public int MediaNumber { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("version")]
        public object Version { get; set; }

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

        [JsonProperty("parental_warning")]
        public bool ParentalWarning { get; set; }

        [JsonProperty("maximum_sampling_rate")]
        public double MaximumSamplingRate { get; set; }

        [JsonProperty("maximum_bit_depth")]
        public int MaximumBitDepth { get; set; }

        [JsonProperty("maximum_channel_count")]
        public int MaximumChannelCount { get; set; }

        [JsonProperty("hires")]
        public bool Hires { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("playlist_track_id")]
        public int PlaylistTrackId { get; set; }

    }

    public class Image
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("back")]
        public object Back { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }

    }

    public class AudioInfo
    {
        [JsonProperty("replaygain_track_gain")]
        public string ReplayGainTrackGain { get; set; }

        [JsonProperty("replaygain_track_peak")]
        public string ReplayGainTrackPeak { get; set; }

    }

    public class Label
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("supplier_id")]
        public int SupplierId { get; set; }

        [JsonProperty("albums_count")]
        public int AlbumsCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

    }

    public class Composer
    {
        [JsonProperty("picture")]
        public object Picture { get; set; }

        [JsonProperty("albums_count")]
        public int AlbumsCount { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }

    public class Artist
    {
        [JsonProperty("picture")]
        public object Picture { get; set; }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("albums_count")]
        public int AlbumsCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

    }

    public class Performer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }

    public class Stream
    {
        [JsonProperty("track_id")]
        public int TrackID { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("url")]
        public string StreamURL { get; set; }

        [JsonProperty("format_id")]
        public int FormatID { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("sampling_rate")]
        public string SampleRate { get; set; }

        [JsonProperty("bit_depth")]
        public string BitDepth { get; set; }

    }

}

