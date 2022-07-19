namespace Poseidon.Usecases.User.GetUserByIdUseCase
{
    using System;
    using Newtonsoft.Json;

    public partial class GetUserByIdResponse
    {
        [JsonProperty("usersPermissionsUser")]
        public UsersPermissionsUser UsersPermissionsUser { get; set; }
    }

    public partial class UsersPermissionsUser
    {
        [JsonProperty("data")]
        public UsersPermissionsUserData Data { get; set; }
    }

    public partial class UsersPermissionsUserData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attributes")]
        public PurpleAttributes Attributes { get; set; }
    }

    public partial class PurpleAttributes
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }
    }

    public partial class Company
    {
        [JsonProperty("data")]
        public CompanyData Data { get; set; }
    }

    public partial class CompanyData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attributes")]
        public FluffyAttributes Attributes { get; set; }
    }

    public partial class FluffyAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("data")]
        public ImageData Data { get; set; }
    }

    public partial class ImageData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("attributes")]
        public TentacledAttributes Attributes { get; set; }
    }

    public partial class TentacledAttributes
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("alternativeText")]
        public string AlternativeText { get; set; }
    }

    public partial class Role
    {
        [JsonProperty("data")]
        public RoleData Data { get; set; }
    }

    public partial class RoleData
    {
        [JsonProperty("attributes")]
        public StickyAttributes Attributes { get; set; }
    }

    public partial class StickyAttributes
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
