using System;
namespace Poseidon.Configs
{
    public static class AppSettings
    {
        //public static string BASE_URL = "https://pos-cms.herokuapp.com";

        //public static string API_TOKEN = "45b1f78675eab6b48e7548bb8b98dac7f15243645b7c317e184faa9917763681a5f0795a7d35fa7da997059ae27f86498ea8b4cf94fc90ec113deab1b8e400ade6f86c02f52f57d727f7981b8e3f9deec48a9fe5778ca78ccae79c7a845e9bda18a91d556cf333a663c48e036293ccca7d2801f3ce2e9b3a71893ce811ebf38b";

        public static string BASE_URL = "http://192.168.1.72:1337";

        public static string API_TOKEN = "7e947353bf3809dcba08634e91dbe8b1702c04cfbf91ec7278760767299d09b21db16b828c96fef0d2cdc6d3c795764ee8df17198fe0c5b6fa236c68556fa18ac4733d6bbfda5aa301397e4dee688eb1f9f8ce73208b0ac21fbab9aa37d48822bf7ff92e8a5c0887663355bb8902759b343cc8732aadd4a869edd20be284b676";

        public static string API_BASE_URL = $"{BASE_URL}/graphql";
    }
}
