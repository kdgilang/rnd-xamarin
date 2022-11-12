using System;
using System.Collections.ObjectModel;
using Poseidon.User.Models;

namespace Poseidon.Models
{

    public class CartModel : BaseModel
    {
        public string Note { set; get; }
        public CartStatus Status { set; get; }
        public UserModel User { get; set; }

        private ObservableCollection<CartItemModel> _items;
        public ObservableCollection<CartItemModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
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
