using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeUpStoreApplication.Common.Models
{
    public class ProductColor
    {

        [JsonProperty("hex_value")]
        public string HexValue { get; set; }

        [JsonProperty("colour_name")]
        public string ColourName { get; set; }
    }

    public class MakeUp
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("price_sign")]
        public string PriceSign { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("image_link")]
        public string ImageLink { get; set; }

        [JsonProperty("product_link")]
        public string ProductLink { get; set; }

        [JsonProperty("website_link")]
        public string WebsiteLink { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("rating")]
        public double? Rating { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("tag_list")]
        public IList<string> TagList { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("product_api_url")]
        public string ProductApiUrl { get; set; }

        [JsonProperty("api_featured_image")]
        public string ApiFeaturedImage { get; set; }

        [JsonProperty("product_colors")]
        public IList<ProductColor> ProductColors { get; set; }
    }



}
