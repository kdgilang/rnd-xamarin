using System;
using System.Collections.Generic;
using Poseidon.User.Models;

namespace Poseidon.Models
{

    public partial class CartModel
    {
        public long Id { set; get; }
        public string Note { set; get; }
        public CartStatus Status { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UserModel User { get; set; }
        public IList<CartItemModel> Items { get; set; }
    }

    public enum CartStatus
    {
        pending,
        cenceled,
        failed,
        paid
    }


    //public partial class Welcome
    //{
    //    [JsonProperty("data")]
    //    public WelcomeData Data { get; set; }
    //}

    //public partial class WelcomeData
    //{
    //    [JsonProperty("carts")]
    //    public Carts Carts { get; set; }
    //}

    //public partial class Attributes
    //{
    //    [JsonProperty("note")]
    //    public string Note { get; set; }

    //    [JsonProperty("status")]
    //    public string Status { get; set; }

    //    [JsonProperty("createdAt")]
    //    public DateTime CreatedAt { get; set; }

    //    [JsonProperty("updatedAt")]
    //    public DateTime UpdatedAt { get; set; }

    //    [JsonProperty("products")]
    //    public Carts Products { get; set; }

    //    [JsonProperty("user")]
    //    public User User { get; set; }
    //}

    //public partial class Datum
    //{
    //    [JsonProperty("id")]
    //    [JsonConverter(typeof(ParseStringConverter))]
    //    public long Id { get; set; }

    //    [JsonProperty("attributes")]
    //    public Attributes Attributes { get; set; }
    //}

    //public partial class Carts
    //{
    //    [JsonProperty("data")]
    //    public List<Datum> Data { get; set; }
    //}

    //public partial class User
    //{
    //    [JsonProperty("data")]
    //    public UserData Data { get; set; }
    //}

    //public partial class UserData
    //{
    //}
}
