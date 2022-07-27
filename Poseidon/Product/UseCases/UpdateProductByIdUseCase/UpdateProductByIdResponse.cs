namespace Poseidon.Product.UseCases.UpdateProductByIdUseCase
{
    using System;
    using Newtonsoft.Json;

    public partial class UpdateProductByIdResponse
    {
        [JsonProperty("updateProduct")]
        public UpdateProduct UpdateProduct { get; set; }
    }

    public partial class UpdateProduct
    {
        [JsonProperty("data")]
        public UpdateProductData Data { get; set; }
    }

    public partial class UpdateProductData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attributes")]
        public PurpleAttributes Attributes { get; set; }
    }

    public partial class PurpleAttributes
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
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

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
        public FluffyAttributes Attributes { get; set; }
    }

    public partial class FluffyAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}

