using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QopenAPI
{
    public class SearchAlbumResult
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("artists")]
        public Artists Artists { get; set; }

        [JsonProperty("albums")]
        public Albums Albums { get; set; }

    }

    public class Artists
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<object> Items { get; set; }

    }

    public class Albums
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<AlbumEx> Items { get; set; }

    }

    public class AlbumEx : Album
    {
        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }     
    }
        
    public class Article
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

    }
      
}

