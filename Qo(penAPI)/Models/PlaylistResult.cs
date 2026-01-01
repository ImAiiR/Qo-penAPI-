using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class PlayListResult
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("playlists")]
        public Playlists Playlists { get; set; }
    }
   
    public class Playlists
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<PlayListExt> Items { get; set; }
    }

    public class PlayListExt : Playlist
    {
      
        [JsonProperty("public_at")]
        public int PublicAt { get; set; }
       
        [JsonProperty("published_from")]
        public int PublishedFrom { get; set; }

        [JsonProperty("published_to")]
        public int PublishedTo { get; set; }       

        [JsonProperty("is_featured")]
        public bool IsFeatured { get; set; }

        [JsonProperty("featured_artists")]
        public List<FeaturedArtists> FeaturedArtists { get; set; }       

        [JsonProperty("timestamp_position")]
        public int TimestampPosition { get; set; }

        [JsonProperty("stores")]
        public List<string> Stores { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }
    }
   
    public class FeaturedArtists
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
}

