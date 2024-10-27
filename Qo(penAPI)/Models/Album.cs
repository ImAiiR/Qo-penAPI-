using Newtonsoft.Json;
using System.Collections.Generic;

namespace QopenAPI
{
    public class Albums
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

    }

    public class Album
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
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("relative_url")]
        public string RelativeUrl { get; set; }

        [JsonProperty("genre")]
        public Genre Genre { get; set; }

        [JsonProperty("genres_list")]
        public List<string> GenresList { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("release_date_download")]
        public string ReleaseDateDownload { get; set; }

        [JsonProperty("release_date_original")]
        public string ReleaseDateOriginal { get; set; }

        [JsonProperty("release_date_stream")]
        public string ReleaseDateStream { get; set; }

        [JsonProperty("maximum_channel_count")]
        public int MaximumChannelCount { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("catchline")]
        public string CatchLine { get; set; }

        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }

        [JsonProperty("product_sales_factors_weekly")]
        public double ProductSalesFactorsWeekly { get; set; }

        [JsonProperty("product_sales_factors_monthly")]
        public double ProductSalesFactorsMonthly { get; set; }

        [JsonProperty("product_sales_factors_yearly")]
        public double ProductSalesFactorsYearly { get; set; }

        [JsonProperty("goodies")]
        public List<Goody> Goodies { get; set; }

        [JsonProperty("composer")]
        public Composer Composer { get; set; }

        [JsonProperty("tracks_count")]
        public int TracksCount { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("released_at")]
        public int ReleasedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("parental_warning")]
        public bool ParentalWarning { get; set; }

        [JsonProperty("articles")]
        public List<Article> Articles { get; set; }

        [JsonProperty("article_ids")]
        public ArticleIds ArticleIds { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("artists")]
        public List<ArtistsList> Artists { get; set; }

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

        [JsonProperty("purchasable_at", NullValueHandling = NullValueHandling.Ignore)]
        public int PurchasableAt { get; set; }

        [JsonProperty("streamable_at", NullValueHandling = NullValueHandling.Ignore)]
        public int StreamableAt { get; set; }

        [JsonProperty("maximum_sampling_rate")]
        public double MaximumSamplingRate { get; set; }

        [JsonProperty("maximum_bit_depth")]
        public int MaximumBitDepth { get; set; }

        [JsonProperty("maximum_technical_specifications")]
        public string MaximumTechnicalSpecifications { get; set; }

        [JsonProperty("awards")]
        public List<Award> Awards { get; set; }

        [JsonProperty("hires")]
        public bool HiRes { get; set; }

        [JsonProperty("hires_streamable")]
        public bool HiResStreamable { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

    }

    public class Goody
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("file_format_id")]
        public int FileFormatId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ArticleIds
    {
        [JsonProperty("LLS")]
        public int LLS { get; set; }

        [JsonProperty("SHP")]
        public int SHP { get; set; }

        [JsonProperty("SMR")]
        public int SMR { get; set; }
    }

    public class ArticleAlbum
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("promotion")]
        public Promotion Promotion { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Promotion
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_price")]
        public double OriginalPrice { get; set; }
    }

    public class Award
    {
        [JsonProperty("publication_name")]
        public string PublicationName { get; set; }

        [JsonProperty("award_slug")]
        public string AwardSlug { get; set; }

        [JsonProperty("publication_id")]
        public string PublicationId { get; set; }

        [JsonProperty("publication_slug")]
        public string PublicationSlug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("award_id")]
        public string AwardId { get; set; }

        [JsonProperty("awarded_at")]
        public int AwardedAt { get; set; }
    }
}

