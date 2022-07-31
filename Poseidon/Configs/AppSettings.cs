using System;
namespace Poseidon.Configs
{
    public static class AppSettings
    {
        public static string BASE_URL = "https://pos-cms.herokuapp.com";

        public static string API_TOKEN = "45b1f78675eab6b48e7548bb8b98dac7f15243645b7c317e184faa9917763681a5f0795a7d35fa7da997059ae27f86498ea8b4cf94fc90ec113deab1b8e400ade6f86c02f52f57d727f7981b8e3f9deec48a9fe5778ca78ccae79c7a845e9bda18a91d556cf333a663c48e036293ccca7d2801f3ce2e9b3a71893ce811ebf38b";

        //public static string BASE_URL = "http://192.168.1.72:1337";

        //public static string API_TOKEN = "c96a077113e53d8a71147e9b118c82df76cb6223676caf57c2afeef7f84d9fad84f0c0ad5c5624253e72b34eedcf3ae0db2223621017e914245c2e837ec3648dc4d675e556c3fa5f7af4e08504fc758e0d75635bda50f89c488d91bfa15bb7c1f787549a55b5182ebacfd87e28007bff27002e0600c34ffb3ab6cfc3f5ce6469";

        public static string API_BASE_URL = $"{BASE_URL}/graphql";
    }
}
