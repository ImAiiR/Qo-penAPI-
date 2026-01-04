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
        // For errors //
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        // End for errors //

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

    public class Favorites
    {
        [JsonProperty("albums")]
        public Albums Albums { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

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
        public object Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("performers")]
        public string Performers { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("picture")]
        public object Picture { get; set; }

        [JsonProperty("favorited_at")]
        public int FavoritedAt { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("performer")]
        public Performer Performer { get; set; }

        [JsonProperty("composer")]
        public Composer Composer { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("isrc")]
        public string ISRC { get; set; }

        [JsonProperty("upc")]
        public string UPC { get; set; }

        [JsonProperty("audio_info")]
        public AudioInfo AudioInfo { get; set; }

        [JsonProperty("albums_count")]
        public int AlbumsCount { get; set; }

        [JsonProperty("media_number")]
        public int MediaNumber { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("track_number")]
        public int TrackNumber { get; set; }

        [JsonProperty("tracks_count")]
        public int TracksCount { get; set; }

        [JsonProperty("version")]
        public object Version { get; set; }

        [JsonProperty("released_at")]
        public long? ReleasedAt { get; set; }

        [JsonProperty("release_date_original")]
        public string ReleaseDateOriginal { get; set; }

        [JsonProperty("release_date_download")]
        public string ReleaseDateDownload { get; set; }

        [JsonProperty("release_date_stream")]
        public string ReleaseDateStream { get; set; }

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

        [JsonProperty("purchasable_at", NullValueHandling = NullValueHandling.Ignore)]
        public int PurchasableAt { get; set; }

        [JsonProperty("streamable_at", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("hires_streamable")]
        public bool HiresStreamable { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("playlist_track_id")]
        public object PlaylistTrackId { get; set; }

        [JsonProperty("qobuz_id")]
        public int QobuzId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("work")]
        public string Work { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

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
        // For errors //
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        // End for errors //

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

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("albums")]
        public Albums Albums { get; set; }

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
        // For errors //
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        // End for errors //

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

        [JsonProperty("biography")]
        public Biography Biography { get; set; }

        [JsonProperty("information")]
        public object Information { get; set; }

        [JsonProperty("albums")]
        public Albums Albums { get; set; }

        [JsonProperty("similar_artist_ids")]
        public List<int> SimilarArtistIds { get; set; }

    }

    public class ArtistsList
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }

    public class Biography
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
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
        // For errors //
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
        // End for errors //

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

