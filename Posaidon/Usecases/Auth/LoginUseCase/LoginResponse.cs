namespace Posaidon.Usecases.Auth.LoginUseCase
{
    using Newtonsoft.Json;

    //public class LoginResponse
    //{
    //    [JsonProperty("data")]
    //    public Data Data { get; set; }
    //}

    public class LoginResponse
    {
        [JsonProperty("login")]
        public Login Login { get; set; }
    }

    public class Login
    {
        [JsonProperty("jwt")]
        public string Jwt { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
