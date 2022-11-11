namespace Poseidon.Product.UseCases.GetProductsByCompanyIdUseCase
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class GetProductsByCompanyIdResponse
    {
        [JsonProperty("products")]
        public Products Products { get; set; }
    }

    public partial class Products
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attributes")]
        public ProductResponse Attributes { get; set; }
    }

    public partial class ProductResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("quantity_notify")]
        public long QuantityNotify { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("member_price")]
        public long MemberPrice { get; set; }

        [JsonProperty("discount")]
        public long Discount { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("data")]
        public ImageData Data { get; set; }
    }

    public partial class ImageData
    {
        [JsonProperty("attributes")]
        public ImageAttributes Attributes { get; set; }
    }

    public partial class ImageAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}
